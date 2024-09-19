using WebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:ProductionConnection"]);
    opts.EnableSensitiveDataLogging();
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
