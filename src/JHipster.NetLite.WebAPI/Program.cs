using JHipster.NetLite.Core;
using JHipster.NetLite.Core.Utils;
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

builder.Services.AddCors(options => //NOSONAR
{ //NOSONAR
    options.AddPolicy( //NOSONAR
        "Open", //NOSONAR
        builder => builder.AllowAnyOrigin().AllowAnyHeader()); //NOSONAR
}); //NOSONAR

var app = builder.Build();
app.UseCors("Open"); //NOSONAR

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
