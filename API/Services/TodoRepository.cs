using API.Data;
using API.Entities;

namespace API.Services;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Todo>> GetTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Todo?> GetTodoAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> CreateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<Todo> UpdateTodoAsync(Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTodoAsync(int id)
    {
        throw new NotImplementedException();
    }
}