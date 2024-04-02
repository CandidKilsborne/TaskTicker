using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo?> GetTodoAsync(int id)
    {
        return await _context.Todos.Where(t => t.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> TodoExistsAsync(int id)
    {
        return await _context.Todos.AnyAsync(t => t.Id == id);
    }

    public async Task SetTodoCompletedAsync(int id)
    {
        var todo = await _context.Todos.Where(t => t.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Todo not found");
        todo.IsCompleted = true;

        await _context.SaveChangesAsync();
    }

    public async Task CreateTodoAsync(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTodoAsync(Todo updatedTodo)
    {
        var todo = _context.Todos.Where(t => t.Id == updatedTodo.Id).FirstOrDefaultAsync();
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }
    }

    public async Task DeleteTodoAsync(int id)
    {
        var todo = await _context.Todos.Where(t => t.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Todo not found");
        _context.Todos.Remove(todo);
    }

    public Task<IEnumerable<SubTask?>> GetSubTasksForTodoAsync(int todoId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DoesTodoExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddSubTaskToTodoAsync(int todoId, SubTask subTask)
    {
        throw new NotImplementedException();
    }
}