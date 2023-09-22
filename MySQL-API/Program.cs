using Microsoft.EntityFrameworkCore;
using MySQL.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
    Cadena de conexion hacia MySQL 
 */
var cadenaConexion = builder.Configuration.GetConnectionString("mysqlConnection");

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseMySql(
        cadenaConexion,
        ServerVersion.AutoDetect(cadenaConexion),  // Auto-detecta la versión del servidor
        options => options.EnableRetryOnFailure()  // Opciones adicionales según tus necesidades
        )
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
