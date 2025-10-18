using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using store.LogicaAplicacion.CU.CUCategory;
using store.LogicaAplicacion.CU.CUProductos;
using store.LogicaAplicacion.CU.CUUsuarios;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaDatos;
using store.LogicaDatos.Repositorios;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dbcontext conf
builder.Services.AddDbContext<eStoreDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
//Repositories injections
builder.Services.AddScoped<IRepositorioUsuarios,RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioProductos,RepositorioProductos>();
builder.Services.AddScoped<IRepositorioCategorias,RepositorioCategorias>();
builder.Services.AddScoped<IRepositorioCompras,RepositorioCompras>();
builder.Services.AddScoped<IRepositorioPrecompras, RepositorioPrecompras>();
builder.Services.AddScoped<IRepositorioReseñas, RepositorioReseñas>();

//CU injections
builder.Services.AddScoped<IAuthorizations, Authorizations>();
builder.Services.AddScoped<ICUChangePass, CUChangePass>();
builder.Services.AddScoped<ICUAltaProd, CUAltaProd>();
builder.Services.AddScoped<ICUBajaProd,CUBajaProd>();
builder.Services.AddScoped<ICUListarProds, CUListarProds>();
builder.Services.AddScoped<ICUObtenerProd, CUObtenerProd>();
builder.Services.AddScoped<ICUListarCategorias, CUListarCategorias>();
builder.Services.AddScoped<ICUAltaCategoria, CUAltaCategoria>();
builder.Services.AddScoped<ICUBajaCategoria, CUBajaCategoria>();

//JWT Service
// Obtener la clave desde la configuración
var claveSecreta = builder.Configuration["JwtSettings:ClaveSecreta"];
var keyBytes = Encoding.UTF8.GetBytes(claveSecreta);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
)
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
        
        
    };
});
// Registrar JwtTokenService como singleton
builder.Services.AddSingleton(
    new JwtTokenService(claveSecreta)
);


builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<eStoreDBContext>();
    context.Database.Migrate(); // Aplica migraciones pendientes
    await DBSeeding.SeedAsync(context); // Ejecuta el seed
}
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
