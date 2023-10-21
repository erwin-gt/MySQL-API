using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MySQL.DataAccess.Models;
using MySQL.Services.Action;
using MySQL.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autorizacion para uso de Token

builder.Configuration.AddJsonFile("appsettings.json"); 
var secretkey = builder.Configuration.GetSection("settings:secretkey").ToString();
var keyBites = Encoding.ASCII.GetBytes(secretkey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBites),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

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
builder.Services.AddTransient<IUsuarioService, UsuarioService>();


//Token
builder.Services.AddTransient<IAutorizacionService, AutorizacionService>();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
