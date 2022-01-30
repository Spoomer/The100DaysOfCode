namespace The100DaysOfCode.Lib.Models;

public class Note : IDbObject
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public int DayOfCodeId { get; set; }
    public DayOfCode? DayOfCode { get; set; }
    public long UtcTimestamp { get; set; }
}
