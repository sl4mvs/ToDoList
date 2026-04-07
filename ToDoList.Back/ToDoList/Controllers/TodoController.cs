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
    private readonly IDatabaseContext _dbContext;

    public TodoController(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("getall")]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var items = await _dbContext.TodoItems
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                IsCompleted = x.IsCompleted
            })
            .ToListAsync();

        return Ok(items);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<TodoDto>> Create([FromBody] TodoDto dto)
    {
        var entity = new TodoEntity
        {
            Title = dto.Title
        };

        _dbContext.TodoItems.Add(entity);
        await _dbContext.SaveChangesAsync();

        return  new TodoDto { Id = entity.Id, Title = entity.Title, CreatedAt = entity.CreatedAt};
    }
    
    [HttpPatch("update")]
    public async Task<ActionResult<TodoDto>> Update([FromBody] TodoDto dto)
    {
        var entity = await _dbContext.TodoItems.FindAsync(dto.Id);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        entity.Title = dto.Title;
        entity.IsCompleted = dto.IsCompleted;
        
        _dbContext.TodoItems.Update(entity);
        await _dbContext.SaveChangesAsync();

        return  new TodoDto { Id = entity.Id, Title = entity.Title, CreatedAt = entity.CreatedAt};
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var entity = await _dbContext.TodoItems.FindAsync(id);
        if (entity == null) return NotFound();

        _dbContext.TodoItems.Remove(entity);
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
}