namespace LeleQuemLimpa.Models;

public class Diva
{
    public Guid ID { get; set; }
    public string Name { get; set; }

    public ICollection<Day> Days { get; set; } = [];
}