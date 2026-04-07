using System;

namespace ToDoList.Dtos;

public class TodoDto
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CreatedAt { get; set; }
}