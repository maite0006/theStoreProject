using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.CU.CUUsuarios;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaDatos;
using store.LogicaDatos.Repositorios;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;

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

//JWT Service
// Obtener la clave desde la configuración
var claveSecreta = builder.Configuration["JwtSettings:ClaveSecreta"];

// Registrar JwtTokenService como singleton
builder.Services.AddSingleton(
    new JwtTokenService(claveSecreta)
);



builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
