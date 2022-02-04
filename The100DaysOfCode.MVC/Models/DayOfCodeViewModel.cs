using System.ComponentModel.DataAnnotations;

namespace The100DaysOfCode.MVC.Models;

public class DayOfCodeViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public ICollection<GoalViewModel> Goals { get; set; } = new List<GoalViewModel>();
    public ICollection<NoteViewModel> Notes { get; set; } = new List<NoteViewModel>();
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public long GetUtcTimestamp()
    {
        return new DateTimeOffset(Date,TimeSpan.FromHours(0)).ToUnixTimeSeconds();
    }
}
