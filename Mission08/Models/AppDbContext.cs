namespace Mission08.Models;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed the Category table with predefined values
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Home" },
            new Category { CategoryId = 2, Name = "School" },
            new Category { CategoryId = 3, Name = "Work" },
            new Category { CategoryId = 4, Name = "Church" }
        );
        
    }
}