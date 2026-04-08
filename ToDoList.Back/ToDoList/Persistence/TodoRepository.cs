using Microsoft.EntityFrameworkCore;
using ToDoList.Entities;
using ToDoList.Persistence.Interfaces;

namespace ToDoList.Persistence;

public class TodoRepository : ITodoRepository
{
    private readonly IDatabaseContext _context;

    public TodoRepository(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoEntity>> GetTodos()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoEntity?> GetTodoById(Guid id)
    {
        return await _context.TodoItems
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TodoEntity> AddTodo(string title)
    {
        var todo = new TodoEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            IsCompleted = false
        };

        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> DeleteTodo(Guid id)
    {
        var todo = await GetTodoById(id);
        if (todo == null) return false;

        _context.TodoItems.Remove(todo);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<TodoEntity?> ChangeTodo(Guid id, string title, bool isCompleted)
    {
        var todo = await GetTodoById(id);
        if (todo == null) return null;

        if (todo.IsCompleted != isCompleted || todo.Title != title)
        {
            todo.IsCompleted = isCompleted;
            todo.Title = title;
            await _context.SaveChangesAsync();
        }

        return todo;
    }
}