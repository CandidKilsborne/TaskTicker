using API.Entities;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public TodosController(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodos()
    {
        var todoEntities = await _repository.GetTodosAsync();
        return Ok(_mapper.Map<IEnumerable<TodoDto>>(todoEntities));
    }

    [HttpGet("{id}", Name = "GetTodo")]
    public async Task<ActionResult<TodoDto>> GetTodo(int id)
    {
        var todo = await _repository.GetTodoAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<TodoDto>(todo));
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> CreateTodo([FromBody] TodoCreationDto todoDto)
    {
        var nextId = (await _repository.GetTodosAsync()).Max(t => t.Id) + 1;
        var todo = _mapper.Map<Todo>(todoDto);

        await _repository.CreateTodoAsync(todo);

        return CreatedAtRoute("GetTodo", new { id = nextId }, todo);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateTodo(int id, [FromBody] TodoDto todoDto)
    // {
    //     var todo = await _repository.GetTodoAsync(id);

    //     if (todo == null)
    //     {
    //         return NotFound();
    //     }

    //     _mapper.Map(todoDto, todo);
    //     await _repository.UpdateTodoAsync(todo);

    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        if (!await _repository.DoesTodoExistAsync(id))
        {
            return NotFound();
        }

        await _repository.DeleteTodoAsync(id);

        return NoContent();
    }
}