using System;
using System.Diagnostics;
using System.IO;

// Script to clean phantom columns from migrations, recreate a clean migration and apply it
// Assumptions:
// - Solution root is the working directory where this tool is executed
// - Migrations project: store.LogicaDatos
// - Startup project: projectAPI
// - dotnet-ef is available on PATH

static class Program
{
    static int Main(string[] args)
    {
        var migrationsPath = Path.Combine("store.LogicaDatos", "Migrations");

        Console.WriteLine("1) Removing old migrations that reference AdministradorId or ClienteId in Productos...");
        if (Directory.Exists(migrationsPath))
        {
            foreach (var file in Directory.GetFiles(migrationsPath, "*.cs"))
            {
                var text = File.ReadAllText(file);
                if (text.Contains("AdministradorId") || text.Contains("ClienteId"))
                {
                    Console.WriteLine($" - Deleting migration file: {file}");
                    File.Delete(file);
                }
            }
        }
        else
        {
            Console.WriteLine("Migrations folder not found, skipping deletion step.");
        }

        // Remove model snapshot if present
        var snapshot = Path.Combine(migrationsPath, "eStoreDBContextModelSnapshot.cs");
        if (File.Exists(snapshot))
        {
            Console.WriteLine(" - Deleting model snapshot.");
            File.Delete(snapshot);
        }

        // IMPORTANT: If the database already exists (tables/migrations history present),
        // applying a new "initial" migration that creates tables will fail because the
        // tables already exist. We drop the database here to ensure a clean state.
        // WARNING: This is destructive. Only do this when the database has no important data.
        Console.WriteLine("1.5) Dropping existing database to ensure a clean migration (destructive)...");
        var dropExit = RunProcess("dotnet", "ef database drop --project store.LogicaDatos --startup-project projectAPI --force");
        if (dropExit != 0)
        {
            Console.WriteLine("Failed to drop database. Aborting to avoid inconsistent state.");
            return 1;
        }

        Console.WriteLine("2) Creating a new initial migration 'CleanInitial'...");
        // dotnet ef migrations add CleanInitial --project store.LogicaDatos --startup-project projectAPI
        if (RunProcess("dotnet", "ef migrations add CleanInitial --project store.LogicaDatos --startup-project projectAPI") != 0)
        {
            Console.WriteLine("Failed to create migration. Aborting.");
            return 1;
        }

        Console.WriteLine("3) Applying migration to the database (database update)...");
        if (RunProcess("dotnet", "ef database update --project store.LogicaDatos --startup-project projectAPI") != 0)
        {
            Console.WriteLine("Failed to apply migration. Aborting.");
            return 1;
        }

        Console.WriteLine("Done.");
        return 0;
    }

    static int RunProcess(string fileName, string arguments)
    {
        var psi = new ProcessStartInfo(fileName, arguments)
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using var p = Process.Start(psi);
        if (p == null) return -1;

        p.OutputDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
        p.ErrorDataReceived += (s, e) => { if (e.Data != null) Console.Error.WriteLine(e.Data); };
        p.BeginOutputReadLine();
        p.BeginErrorReadLine();
        p.WaitForExit();
        return p.ExitCode;
    }
}
