#nullable disable

using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.MVC.Data;
public class DayOfCodeContext : DbContext
{
    public DayOfCodeContext(DbContextOptions<DayOfCodeContext> options)
        : base(options)
    {
    }

    public DbSet<The100DaysOfCode.MVC.Models.DayOfCode> DayOfCode { get; set; }
}
