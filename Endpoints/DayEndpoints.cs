using LeleQuemLimpa.Models;
using LeleQuemLimpa.Payloads;
using LeleQuemLimpa.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeleQuemLimpa.Endpoints;

public static class DayEndpoints
{
    public static void ConfigureDayEndpoints(this WebApplication app)
    {
        app.MapGet("/today", async ([FromServices]IDayRepository dayRepo) =>
        {
            var today = await dayRepo.GetNextDay();
            if (today is null)
                return Results.NotFound();
            
            return Results.Ok(today);
        });

        app.MapPut("/today/done", async ([FromServices]IDayRepository dayRepo) =>
        {
            var today = await dayRepo.GetNextDay();
            if (today is null)
                return Results.NotFound();
            
            today.Done = true;
            today.DoneAt = DateTime.Now;
            await dayRepo.Update(today);
            return Results.Ok();
        });

        app.MapPost("/day", async (
            [FromBody]DayCreatePayload day,
            [FromServices]IDayRepository dayRepo,
            [FromServices]IDivaRepository divaRepo) =>
        {
            List<Diva> divas = [];
            foreach (var id in day.DivasIds)
            {
                var diva = await divaRepo.GetByID(id);
                if (diva is null)
                    continue;
                divas.Add(diva);
            }

            var newDay = new Day {
                Done = false,
                DoneAt = null,
                Divas = divas
            };
            await dayRepo.Create(newDay);
            return Results.Ok();
        });
    }
}