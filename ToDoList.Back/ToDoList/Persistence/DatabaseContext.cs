using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;
using ToDoList.Persistence.Interfaces;

namespace ToDoList.Persistence;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<TodoEntity> TodoItems { get; set; }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoEntity>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).IsRequired().HasMaxLength(2000);
            entity.Property(x => x.IsCompleted).HasDefaultValue(false);
            entity.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
        });
    }
}