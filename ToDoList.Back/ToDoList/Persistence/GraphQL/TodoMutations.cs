using HotChocolate;
using ToDoList.Entities;

namespace ToDoList.Persistence.GraphQL;

public class TodoMutations
{
    public TodoEntity AddTodo(string title, [Service] TodoRepository repo) => repo.AddTodo(title);

    public bool DeleteTodo(Guid id, [Service] TodoRepository repo) => repo.DeleteTodo(id);

    public TodoEntity? ToggleTodo(Guid id, [Service] TodoRepository repo) => repo.ToggleTodo(id);
}