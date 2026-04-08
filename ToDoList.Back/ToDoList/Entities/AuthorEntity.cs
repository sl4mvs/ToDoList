namespace ToDoList.Entities;

public class AuthorEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<TodoEntity> Todos { get; set; }
}