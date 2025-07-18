namespace LeleQuemLimpa.Models;

public class Day
{
    public int ID { get; set; }
    public bool Done { get; set; }
    public DateTime? DoneAt { get; set; }

    public ICollection<Diva> Divas { get; set; } = [];
}