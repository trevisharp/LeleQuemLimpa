using LeleQuemLimpa.Models;
using LeleQuemLimpa.Payloads;
using LeleQuemLimpa.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeleQuemLimpa.Controllers;

[ApiController]
[Route("divas")]
public class DivaController(IDivaRepository repo) : ControllerBase
{
    [HttpGet("{search}")]
    public async Task<IActionResult> GetDivas(string search)
    {  
        var divas = await repo.Search(search);
        if (divas.Count() == 0) {
            return NotFound();
        }

        return Ok(divas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiva([FromBody]DivaCreatePayload diva)
    {
        var divas = await repo.Search(diva.Name);
        if (divas.Any(d => d.Name == diva.Name))
            return BadRequest($"already exists a diva with name '{diva.Name}'");

        await repo.Create(new Diva {
            Name = diva.Name
        });
        return Ok();

    }
}