using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Dtos;
using ToDoList.Entities;
using ToDoList.Persistence.Interfaces;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : Controller
{
    private readonly ITodoRepository _todoRepository;

    public TodoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var items = await _todoRepository.GetTodos();

        var dtos = items
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            })
            .ToList();

        return Ok(dtos);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<TodoDto>> Create([FromBody] TodoDto dto)
    {
        var entity = await _todoRepository.AddTodo(dto.Title);

        var result = new TodoDto
        {
            Id = entity.Id,
            Title = entity.Title,
            IsCompleted = entity.IsCompleted,
            CreatedAt = entity.CreatedAt
        };

        return Ok(result);
    }
    
    [HttpPatch("update")]
    public async Task<ActionResult<TodoDto>> Update([FromBody] TodoDto dto)
    {
        if (dto.Id == Guid.Empty) return BadRequest();
        var entity = await _todoRepository.GetTodoById(dto.Id.Value);

        if (entity == null)
            return NotFound();

        entity.Title = dto.Title;
        entity.IsCompleted = dto.IsCompleted;

        await _todoRepository.ChangeTodo(entity.Id, dto.Title, dto.IsCompleted); 

        var result = new TodoDto
        {
            Id = entity.Id,
            Title = entity.Title,
            IsCompleted = entity.IsCompleted,
            CreatedAt = entity.CreatedAt
        };

        return Ok(result);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleted = await _todoRepository.DeleteTodo(id);
        if (!deleted) return NotFound();

        return Ok();
    }
}