﻿using JHipster.NetLite.Web;
using JHipster.NetLite.Web.Utils;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJHipsterLite();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{JHipsterLiteConstantes.JHipsterLiteAssembly}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("Open");

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
