using HotChocolate;
using ToDoList.Entities;

namespace ToDoList.Persistence.GraphQL;

public class TodoQueries
{
    public IEnumerable<TodoEntity> GetTodos([Service] TodoRepository repo) => repo.GetTodos();

    public TodoEntity? GetTodoById(Guid id, [Service] TodoRepository repo) => repo.GetTodoById(id);
}