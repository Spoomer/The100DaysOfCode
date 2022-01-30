#nullable disable

using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.MVC.Data;
public class DayOfCodeContext : DbContext
{
    public DayOfCodeContext(DbContextOptions<DayOfCodeContext> options)
        : base(options)
    {
    }

    public DbSet<DayOfCodeViewModel> DaysOfCode { get; set; }
    public DbSet<GoalViewModel> Goals { get; set; }
    public DbSet<NoteViewModel> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DayOfCodeViewModel>().ToTable("DayOfCode");
        modelBuilder.Entity<GoalViewModel>().ToTable("Goal");
        modelBuilder.Entity<NoteViewModel>().ToTable("Note");
    }
}
