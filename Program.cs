using FluentValidation.AspNetCore;
using LaboratorioManagerAPI.Models;
using LaboratorioManagerAPI.Repositories;
using LaboratorioManagerAPI.Repositories.Intefaces;
using LaboratorioManagerAPI.Services;
using LaboratorioManagerAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExperimentosRepository, ExperimentoRepository>();
builder.Services.AddScoped<IExperimentosService, ExperimentosService>();
builder.Services.AddScoped<ICientificosRepository, CientificosRepository>();
builder.Services.AddScoped<ICientificosService, CientificosService>();
builder.Services.AddScoped<ICientificosXexperimentosRepository, CientificosXexperimentosRepository>();
builder.Services.AddScoped<ICientificosXExperimentosService, CientificosXExperimentosService>();

builder.Services.AddDbContext<LaboratorioDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});



builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
