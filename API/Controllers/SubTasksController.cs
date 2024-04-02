using API.Entities;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/{todoId}/[controller]")]
public class SubTasksController : ControllerBase
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public SubTasksController(ITaskRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubTaskDto>>> GetSubTasks(int todoId)
    {
        var todo = await _repository.GetTodoAsync(todoId);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<IEnumerable<SubTaskDto>>(todo.SubTasks));
    }

    [HttpGet("{id}", Name = "GetSubTask")]
    public async Task<ActionResult<SubTaskDto>> GetSubTask(int todoId, int id)
    {
        var todo = await _repository.GetTodoAsync(todoId);
        if (todo == null)
        {
            return NotFound();
        }

        var subTask = todo.SubTasks.FirstOrDefault(st => st.Id == id);
        if (subTask == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SubTaskDto>(subTask));
    }

    [HttpPost]
    public async Task<ActionResult<SubTaskDto>> CreateSubTask(int todoId, [FromBody] SubTaskCreationDto subTask)
    {
        var todo = await _repository.GetTodoAsync(todoId);
        if (!await _repository.DoesTodoExistAsync(todoId) || todo == null)
        {
            return NotFound();
        }

        var subTaskEntity = _mapper.Map<SubTask>(subTask);
        subTaskEntity.Id = todo.SubTasks.Max(st => st.Id) + 1;

        await _repository.AddSubTaskToTodoAsync(todoId, subTaskEntity);

        var subTaskDto = _mapper.Map<SubTaskDto>(subTaskEntity);

        return CreatedAtRoute("GetSubTask", new { todoId, id = subTaskDto.Id }, subTaskDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubTask(int todoId, int id)
    {
        var todo = await _repository.GetTodoAsync(todoId);
        if (todo == null)
        {
            return NotFound();
        }

        var subTask = todo.SubTasks.FirstOrDefault(st => st.Id == id);
        if (subTask == null)
        {
            return NotFound();
        }

        todo.SubTasks.Remove(subTask);

        return NoContent();
    }
}