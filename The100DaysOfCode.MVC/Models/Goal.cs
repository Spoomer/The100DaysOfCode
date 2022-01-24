namespace The100DaysOfCode.MVC.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Check {get; set;}
        public int DayOfCodeId { get; set; }
        public DayOfCode? DayOfCode { get; set; }
    }
}