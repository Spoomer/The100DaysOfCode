namespace The100DaysOfCode.Lib.Models;

public class DayOfCode : IDbObject
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    public ICollection<Note> Notes { get; set; } = new List<Note>();
    public long UtcTimestamp { get; set; }
}
