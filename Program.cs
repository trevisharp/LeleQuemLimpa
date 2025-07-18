using LeleQuemLimpa.Implementations;
using LeleQuemLimpa.Models;
using LeleQuemLimpa.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LeleQuemLimpaDbContext>(
    options => options.UseSqlServer(
        Environment.GetEnvironmentVariable("SQL_CONNECTION")
    )
);

builder.Services.AddTransient<IDivaRepository, EFDivaRepository>();

var app = builder.Build();

app.MapGet("divas/{search}", async (string search, [FromServices]IDivaRepository repo) => 
{
    var divas = await repo.Search(search);
    if (divas.Count() == 0) {
        return Results.NotFound();
    }

    return Results.Ok(divas);
});

app.MapPost("divas", ([FromBody]Diva diva) =>
{

});

app.Run();
