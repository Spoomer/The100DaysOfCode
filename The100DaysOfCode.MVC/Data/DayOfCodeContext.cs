#nullable disable

using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.MVC.Data;
public class DayOfCodeContext : DbContext
{
    public DayOfCodeContext(DbContextOptions<DayOfCodeContext> options)
        : base(options)
    {
    }

    public DbSet<DayOfCode> DayOfCode { get; set; }
}
