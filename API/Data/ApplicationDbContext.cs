using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TopLevelTodo>().HasData(
            new TopLevelTodo("Top level todo")
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(7)
            },
            new TopLevelTodo("Another top level todo")
            {
                Id = 2,
                DueDate = DateTime.Now.AddDays(14)
            },
            new TopLevelTodo("Yet another top level todo")
            {
                Id = 3,
                DueDate = DateTime.Now.AddDays(21)
            }
        );
    }
}