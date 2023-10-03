using Microsoft.EntityFrameworkCore;
using MySQL.DataAccess.Models;
using MySQL.Services.Action;
using MySQL.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
    Cadena de conexion hacia MySQL 
 */
var cadenaConexion = builder.Configuration.GetConnectionString("mysqlConnection");

builder.Services.AddDbContext<ProyectoContext>(x =>
    x.UseMySql(
        cadenaConexion,
        ServerVersion.AutoDetect(cadenaConexion),  // Auto-detecta la versión del servidor
        options => options.EnableRetryOnFailure()  // Opciones adicionales según tus necesidades
        )
    );


//Inicio de Implementacion de los Servicios para cada uno de los Modelos

builder.Services.AddTransient<iPuestoService, PuestoService>();
builder.Services.AddTransient<IEstudianteService, EstudianteService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<ICarreraService, CarreraService>();
builder.Services.AddTransient<IInscripcionService, InscripcionService>();
builder.Services.AddTransient<ICursoService, CursoService>();
builder.Services.AddTransient<INotaService, NoteService>();
builder.Services.AddTransient<IGradoService, GradoService>();

//Fin de Implementacion de los Servicios para cada uno de los Modelos

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
