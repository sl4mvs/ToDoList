using HotChocolate;
using ToDoList.Entities;
using ToDoList.Persistence.Interfaces;

namespace ToDoList.Persistence.GraphQL;

public class TodoQueries
{
    public Task<IEnumerable<TodoEntity>> GetTodos([Service] ITodoRepository repository) => repository.GetTodos();

    public Task<TodoEntity?> GetTodoById(Guid id, [Service] ITodoRepository repo) => repo.GetTodoById(id);
}