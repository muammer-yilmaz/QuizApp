using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Common;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence;

public class AppDbContext : IdentityDbContext<AppUser,AppRole,string>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<QuizAttempt> QuizAttempts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<QuizAttempt>(entity =>
        {
            entity.HasOne(p => p.Quiz).WithMany().OnDelete(DeleteBehavior.NoAction);
            //entity.HasOne(p => p.QuizId).WithMany().OnDelete(DeleteBehavior.NoAction);
        });
        base.OnModelCreating(builder);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    //entry.Entity.Id = Guid.NewGuid().ToString();
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = DateTime.UtcNow;
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
