using LeleQuemLimpa.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LeleQuemLimpaDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
