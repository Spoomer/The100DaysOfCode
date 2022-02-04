#nullable disable

using Microsoft.EntityFrameworkCore;

namespace The100DaysOfCode.Lib;
public class DayOfCodeContext : DbContext
{
    public DayOfCodeContext(DbContextOptions<DayOfCodeContext> options)
        : base(options)
    {
    }

    public DbSet<DayOfCode> DaysOfCode { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DayOfCode>().ToTable("DayOfCode");
        modelBuilder.Entity<Goal>().ToTable("Goal");
        modelBuilder.Entity<Note>().ToTable("Note");
    }
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // => options.UseSqlite("Data Source=DaysOfCode.db");
}
