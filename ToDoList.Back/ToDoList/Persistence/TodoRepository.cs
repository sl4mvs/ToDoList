using ToDoList.Entities;

namespace ToDoList.Persistence;

public class TodoRepository
{
    private readonly List<TodoEntity> _todos = new List<TodoEntity>();

    public IEnumerable<TodoEntity> GetTodos() => _todos;

    public TodoEntity? GetTodoById(Guid id) => _todos.FirstOrDefault(t => t.Id == id);

    public TodoEntity AddTodo(string title)
    {
        var todo = new TodoEntity { Title = title };
        _todos.Add(todo);
        return todo;
    }

    public bool DeleteTodo(Guid id)
    {
        var todo = GetTodoById(id);
        if (todo == null) return false;
        _todos.Remove(todo);
        return true;
    }

    public TodoEntity? ToggleTodo(Guid id)
    {
        var todo = GetTodoById(id);
        if (todo == null) return null;
        todo.IsCompleted = !todo.IsCompleted;
        return todo;
    }
}