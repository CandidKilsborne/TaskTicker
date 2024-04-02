using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasData(
            new Todo("Top level todo")
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(7)
            },
            new Todo("Another top level todo")
            {
                Id = 2,
                DueDate = DateTime.Now.AddDays(14)
            },
            new Todo("Yet another top level todo")
            {
                Id = 3,
                DueDate = DateTime.Now.AddDays(21)
            }
        );

        modelBuilder.Entity<SubTask>().HasData(
            new SubTask("Sub task 1")
            {
                Id = 1,
                DueDate = DateTime.Now.AddDays(1),
                TodoId = 1
            },
            new SubTask("Sub task 2")
            {
                Id = 2,
                DueDate = DateTime.Now.AddDays(2),
                TodoId = 1
            },
            new SubTask("Sub task 3")
            {
                Id = 3,
                DueDate = DateTime.Now.AddDays(3),
                TodoId = 2
            }
        );
    }
}