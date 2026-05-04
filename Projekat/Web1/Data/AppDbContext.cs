using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Web1.Models.Entities;
namespace Web1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Result> Results { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Result)
            .WithMany()
            .HasForeignKey(ua => ua.ResultId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<UserAnswer>()
            .HasOne(ua => ua.Question)
            .WithMany()
            .HasForeignKey(ua => ua.QuestionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
