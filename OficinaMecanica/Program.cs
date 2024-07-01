using Microsoft.EntityFrameworkCore;
using OficinaMecanica.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
        opt.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

//String de conexao com o banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Conex�o com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection,
        ServerVersion.AutoDetect(mySqlConnection)));

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
