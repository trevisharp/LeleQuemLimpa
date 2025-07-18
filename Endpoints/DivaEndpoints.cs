using LeleQuemLimpa.Models;
using LeleQuemLimpa.Payloads;
using LeleQuemLimpa.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeleQuemLimpa.Endpoints;

public static class DivaEndpoints
{
    public static void ConfigureDivaEndpoints(this WebApplication app)
    {
        app.MapGet("divas/{search}", async (string search, [FromServices]IDivaRepository repo) => 
        {
            var divas = await repo.Search(search);
            if (divas.Count() == 0) {
                return Results.NotFound();
            }

            return Results.Ok(divas);
        });

        app.MapPost("divas", async (
            [FromBody]DivaCreatePayload diva,
            [FromServices]IDivaRepository repo) =>
        {
            var divas = await repo.Search(diva.Name);
            if (divas.Any(d => d.Name == diva.Name))
                return Results.BadRequest($"already exists a diva with name '{diva.Name}'");

            await repo.Create(new Diva {
                Name = diva.Name
            });
            return Results.Ok();
        });

    }
}