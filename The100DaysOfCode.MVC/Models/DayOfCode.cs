using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.MVC.Models
{
    public class DayOfCode
    {
        public int Id { get; set; }
        public string Title {get; set;} ="";
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}