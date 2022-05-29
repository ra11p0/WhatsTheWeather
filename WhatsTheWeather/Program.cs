using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAccess;
using WhatsTheWeatherDatabaseAccess;

const string API_KEY = "ec2ebff3d5a53f60c257210f76fc1fdf";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StatisticsDbContext>(e =>
{
    e.UseSqlServer(builder.Configuration.GetConnectionString("StatisticsConnectionString"), o=>o.MigrationsAssembly("WhatsTheWeather"));
});

builder.Services.AddScoped(_=>new WeatherService(API_KEY));
builder.Services.AddScoped(_ => new ForecastService(API_KEY));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("Location",
    "Location/{cityName}",
    new { Controller = "Location", Action = "Index" });

app.MapDefaultControllerRoute();

app.Run();
