using LeleQuemLimpa.Models;
using LeleQuemLimpa.Services;
using Microsoft.EntityFrameworkCore;

namespace LeleQuemLimpa.Implementations;

public class EFDivaRepository(LeleQuemLimpaDbContext ctx) : IDivaRepository
{
    public async Task<Guid?> Create(Diva diva)
    {
        ctx.Divas.Add(diva);
        await ctx.SaveChangesAsync();
        return diva.ID;
    }

    public async Task<Diva?> GetByID(Guid id)
    {
        return await ctx.Divas
            .FirstOrDefaultAsync(d => d.ID == id);
    }

    public async Task<IEnumerable<Diva>> Search(string name)
    {
        return await ctx.Divas
            .Where(d => d.Name.Contains(name))
            .ToListAsync();
    }
}