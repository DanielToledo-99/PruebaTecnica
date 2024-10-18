using IlustraApp.Infrastructure;
using Microsoft.OpenApi.Models;
using PruebaTecnicaAPI.Data;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddInfrastructure(configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => new OpenApiInfo { Title = "Prueba Técnica", Version = "v1" });
var app = builder.Build();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaTecnicaDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
