using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using store.LogicaAplicacion.CU.CUArticulos;
using store.LogicaAplicacion.CU.CUCarrito;
using store.LogicaAplicacion.CU.CUCategory;
using store.LogicaAplicacion.CU.CUCompra;
using store.LogicaAplicacion.CU.CUProductos;
using store.LogicaAplicacion.CU.CUUsuarios;
using store.LogicaAplicacion.ICU.ICUArticulos;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.ICU.ICUCompra;
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
   { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
       options.LogTo(Console.WriteLine, LogLevel.Information);

   });
//Repositories injections
builder.Services.AddScoped<IRepositorioUsuarios,RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioProductos,RepositorioProductos>();
builder.Services.AddScoped<IRepositorioCategorias,RepositorioCategorias>();
builder.Services.AddScoped<IRepositorioCompras,RepositorioCompras>();
builder.Services.AddScoped<IRepositorioPrecompras, RepositorioPrecompras>();
builder.Services.AddScoped<IRepositorioReseñas, RepositorioReseñas>();

//CU injections
// Usuario
builder.Services.AddScoped<IAuthorizations, Authorizations>();//Login y SignUp(Este ultimo unicamente para CLI)
builder.Services.AddScoped<ICUChangePass, CUChangePass>();
builder.Services.AddScoped<ICUAgregarFavorito, CUAgregarFavorito>();
builder.Services.AddScoped<ICUEliminarFavorito, CUEliminarFavorito>();
builder.Services.AddScoped<ICUListarFavoritos, CUListarFavoritos>();
// Productos
builder.Services.AddScoped<ICUAltaProd, CUAltaProd>();
builder.Services.AddScoped<ICUBajaProd,CUBajaProd>();
builder.Services.AddScoped<ICUListarProds, CUListarProds>();
builder.Services.AddScoped<ICUObtenerProd, CUObtenerProd>();
// Categorias
builder.Services.AddScoped<ICUListarCategorias, CUListarCategorias>();
builder.Services.AddScoped<ICUAltaCategoria, CUAltaCategoria>();
builder.Services.AddScoped<ICUBajaCategoria, CUBajaCategoria>();
// Precompra/Carrito
builder.Services.AddScoped<store.LogicaAplicacion.ICU.ICUCarrito.ICUOperarArticuloCarrito, CUOperarArticuloCarrito>();
builder.Services.AddScoped<ICUCerrarPrecompra, CUCerrarPrecompra>();
builder.Services.AddScoped<ICUVerCarrito, CUVerCarrito>();
builder.Services.AddScoped<ICUVaciarCarrito, ICUVaciarCarrito>();
//Compra
builder.Services.AddScoped<ICUActualizarEstadoEnvio, CUActualizarEstadoEnvio>();
builder.Services.AddScoped<ICUConfigurarCompra, CUConfiguracionCompra>();
builder.Services.AddScoped<ICUConfirmarPago, CUConfirmarPago>();
builder.Services.AddScoped<ICUVerDetalle, CUVerDetalle>();
builder.Services.AddScoped<ICUVerHistorial, CUVerHistorial>();




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


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
