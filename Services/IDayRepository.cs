using LeleQuemLimpa.Models;

namespace LeleQuemLimpa.Services;

public interface IDayRepository
{
    Task<Day> GetNextDay();
    Task Create(Day day);
    Task Update(Day day);
}