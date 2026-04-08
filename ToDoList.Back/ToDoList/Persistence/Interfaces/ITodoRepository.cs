using ToDoList.Entities;

namespace ToDoList.Persistence.Interfaces;

public interface ITodoRepository
{
    Task<IEnumerable<TodoEntity>> GetTodos();
    Task<TodoEntity?> GetTodoById(Guid id);
    Task<TodoEntity> AddTodo(string title);
    Task<bool> DeleteTodo(Guid id);
    Task<TodoEntity?> ChangeTodo(Guid id,  string title, bool isCompleted);
}