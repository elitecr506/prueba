using Ecommerce.SOS.Gateway.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);
string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
string url = $"http://0.0.0.0:{port}";

// Add services to the container.

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = false;
    x.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependenciesInjection.InjectDependencies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(url: url);

