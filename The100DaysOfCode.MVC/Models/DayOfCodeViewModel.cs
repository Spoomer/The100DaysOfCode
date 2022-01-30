using System.ComponentModel.DataAnnotations;

namespace The100DaysOfCode.MVC.Models;

public class DayOfCodeViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public ICollection<GoalViewModel> Goals { get; set; } = new List<GoalViewModel>();
    public ICollection<NoteViewModel> Notes { get; set; } = new List<NoteViewModel>();
    [DataType(DataType.Date)]
    public DateTimeOffset Date { get; set; }

    // public DayOfCodeViewModel() { }

    // public DayOfCodeViewModel(DayOfCode dayOfCode)
    // {
    //     Id = dayOfCode.Id;
    //     Title = dayOfCode.Title;
    //     Goals = dayOfCode.Goals.Select<Goal,GoalViewModel>(x=> GoalViewModel(x));
    //     Notes = dayOfCode.Notes.Select<Note,NoteViewModel>(x=> NoteViewModel(x));
    //     Date = DateTimeOffset.FromUnixTimeSeconds(dayOfCode.UtcTimestamp);
    // }

}
