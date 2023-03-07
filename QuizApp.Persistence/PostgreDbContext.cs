using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Domain.Common;
using QuizApp.Domain.Entities;
using QuizApp.Domain.Entities.Identity;

namespace QuizApp.Persistence;

public class PostgreDbContext // : IdentityDbContext<AppUser, AppRole, string>, IDbContext
{
    public PostgreDbContext() : base()
    {
    }

    //public PostgreDbContext(DbContextOptions<PostgreDbContext> contextOptions) : base(contextOptions)
    //{

    //}

    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<QuizAttempt> QuizAttempts { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<AppUser>()
    //        .Property(p => p.ProfilePictureUrl)
    //        .HasDefaultValue("https://res.cloudinary.com/dn8tmbsj3/image/upload/v1677684961/profiles/default.png");

    //    base.OnModelCreating(builder);
    //}


    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    var entries = ChangeTracker.Entries<BaseEntity>();

    //    foreach (var entry in entries)
    //    {
    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreatedDate = DateTime.UtcNow;
    //                break;
    //            case EntityState.Modified:
    //                entry.Entity.UpdatedDate = DateTime.UtcNow;
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    return base.SaveChangesAsync(cancellationToken);
    //}

}
