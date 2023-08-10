using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.Reminders;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using StudyTrackerSystem.Domain.Entities.Subjects;
using StudyTrackerSystem.Domain.Entities.Teachers;
using StudyTrackerSystem.Domain.Entities.TextBooks;

namespace StudyTrackerSystem.Data.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<StudyResult> StudyResults { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TextBook> TextBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=StudyTrackerSystem; Trusted_Connection=true";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>()
            .HasOne(g => g.Group)
            .WithMany(s => s.Students)
            .HasForeignKey(g => g.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Reminder>()
            .HasOne(s => s.Student)
            .WithMany(r => r.Reminders)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Teacher>()
            .HasOne(g => g.Group)
            .WithMany(t => t.Teachers)
            .HasForeignKey(g => g.GroupId);

        modelBuilder.Entity<StudyResult>()
              .HasOne(sr => sr.Student)
              .WithMany(s => s.StudyResults)
              .HasForeignKey(sr => sr.StudentId);


        modelBuilder.Entity<Subject>()
            .HasMany(t => t.TextBooks)
            .WithOne(s => s.Subject)
            .HasForeignKey(s => s.SubjectId);


        modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasColumnType("decimal(18, 2)");
    }
}
