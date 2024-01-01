
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

internal class ApplicationDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseInMemoryDatabase("TaskDb");
        }
    }
}
