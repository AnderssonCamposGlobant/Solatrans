using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.BusinessLogic.Logic;
using RegistroAveriasApi.Core.Interfaces;
using RegistroAveriasApi.Core.Profiles;
using RegistroAveriasApi.WebApi.Config;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddDbContext<AppDbContext>(opt => {

    System.Console.WriteLine("String de conexion" + builder.Configuration.GetConnectionString("AveriasConn"));
    opt.UseNpgsql(builder.Configuration.GetConnectionString("AveriasConn"));
});

builder.Services.AddControllers().AddJsonOptions(json => {
    json.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    json.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddTransient<IEstadoAveriasRepository, EstadoAveriasRepository>();
builder.Services.AddTransient<IAveriaRepository, AveriaRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IRolRepository, RolesRepository>();
builder.Services.AddTransient<ITipoAveriaRepository, TipoAveriaRepository>();
builder.Services.AddTransient<ITipoServicioRepository, TipoServicioRepository>();

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

app.UseMiddleware<MiddlewareErrorHandler>();

app.MapControllers();

app.Run();
