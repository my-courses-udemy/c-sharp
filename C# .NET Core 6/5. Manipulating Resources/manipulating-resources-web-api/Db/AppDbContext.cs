using first_web_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace first_web_api.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthorBook>()
            .HasKey(ab => new { ab.AuthorId, ab.BookId });
    }

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<AuthorBook> AuthorsBooks { get; set; } = null!;
}