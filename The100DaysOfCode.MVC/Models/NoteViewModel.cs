using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.MVC.Models
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public int DayOfCodeId { get; set; }
        public DayOfCodeViewModel? DayOfCode { get; set; }
    }
}