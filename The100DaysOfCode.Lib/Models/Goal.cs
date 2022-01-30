namespace The100DaysOfCode.Lib.Models;

public class Goal : IDbObject
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool Check { get; set; }
    public int DayOfCodeId { get; set; }
    public DayOfCode? DayOfCode { get; set; }
    public long UtcTimestamp { get; set; }
}
