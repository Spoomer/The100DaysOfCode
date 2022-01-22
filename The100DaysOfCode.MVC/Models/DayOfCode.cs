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
        public List<Goal> Goals { get; set; } = new();
        public List<Note> Notes { get; set; } = new();
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}