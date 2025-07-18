using LeleQuemLimpa.Models;

namespace LeleQuemLimpa.Services;

public interface IDivaRepository
{
    Task<IEnumerable<Diva>> Search(string name);
    Task<Diva?> GetByID(Guid id);
    Task<Guid?> Create(Diva diva);
}