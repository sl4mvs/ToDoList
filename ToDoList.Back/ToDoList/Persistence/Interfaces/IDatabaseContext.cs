using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;

namespace ToDoList.Persistence.Interfaces;
public interface IDatabaseContext
{
    DbSet<TodoEntity> TodoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}