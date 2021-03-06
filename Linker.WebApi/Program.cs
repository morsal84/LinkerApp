using Linker.Application.Repositories;
using Linker.Application.Repositories.Link;
using Linker.Application.Services.Commands;
using Linker.Application.Services.Queries;
using Linker.Persistence;
using Linker.Persistence.Repositories;
using Linker.Persistence.Repositories.Link;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateAbrevationCommand));
builder.Services.AddMediatR(typeof(GetUrlQuery));
builder.Services.AddMediatR(typeof(GetVisitCountQuery));

builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
builder.Services.AddScoped<ILinkRepository, LinkRepository>();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<LinkerContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//app.UseAuthorization();
//app.MapControllers();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
//app.MapGet("/links", () =>
//{
//    return "Test";
//})
//.WithName("Links");

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//       new WeatherForecast
//       (
//           DateTime.Now.AddDays(index),
//           Random.Shared.Next(-20, 55),
//           summaries[Random.Shared.Next(summaries.Length)]
//       ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}