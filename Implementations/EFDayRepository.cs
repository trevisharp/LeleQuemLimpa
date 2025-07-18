using LeleQuemLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace LeleQuemLimpa.Services;

public class EFDayRepository(LeleQuemLimpaDbContext ctx) : IDayRepository
{
    public async Task Create(Day day)
    {
        ctx.Days.Add(day);
        await ctx.SaveChangesAsync();
    }

    public async Task<Day> GetNextDay()
    {
        var query = 
            from d in ctx.Days.Include(d => d.Divas)
            where !d.Done
            orderby d.ID ascending
            select d;
        
        var nextDay = await query.FirstOrDefaultAsync();
        return nextDay;
    }

    public async Task Update(Day day)
    {
        ctx.Update(day);
        await ctx.SaveChangesAsync();
    }
}