using Microsoft.EntityFrameworkCore;
using WebAPI.Entity.Concrete;

namespace WebAPI.DataAccess.Data;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WebAPIDatabase;Username=myuser;Password=mypassword");
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Comment> Comments { get; set; }
}