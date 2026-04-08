using ToDoList.Entities;
using ToDoList.Persistence.Interfaces;

namespace ToDoList.Persistence.GraphQL;

public class TodoMutations
{
    public Task<TodoEntity> AddTodo(string title, [Service] ITodoRepository repo) => repo.AddTodo(title);

    public Task<bool> DeleteTodo(Guid id, [Service] ITodoRepository repo) => repo.DeleteTodo(id);

    public Task<TodoEntity?> ChangeTodo(Guid id, string title, bool isCompleted, [Service] ITodoRepository repo) => repo.ChangeTodo(id, title, isCompleted);
}