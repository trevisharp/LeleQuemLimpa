using LeleQuemLimpa.Endpoints;
using LeleQuemLimpa.Implementations;
using LeleQuemLimpa.Models;
using LeleQuemLimpa.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();

builder.Services.AddDbContext<LeleQuemLimpaDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);

builder.Services.AddTransient<IDivaRepository, EFDivaRepository>();

var app = builder.Build();

// app.MapControllers();
app.ConfigureDivaEndpoints();

app.Run();
