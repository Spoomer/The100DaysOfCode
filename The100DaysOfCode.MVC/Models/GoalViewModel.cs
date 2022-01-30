namespace The100DaysOfCode.MVC.Models
{
    public class GoalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Check {get; set;}
        public int DayOfCodeId { get; set; }
        public DayOfCodeViewModel? DayOfCode { get; set; }
    }
}