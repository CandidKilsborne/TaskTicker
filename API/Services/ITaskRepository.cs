using API.Entities;

namespace API.Services;

public interface ITaskRepository
{
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<Todo?> GetTodoAsync(int id);
    Task<bool> DoesTodoExistAsync(int id);
    Task SetTodoCompletedAsync(int id);
    Task CreateTodoAsync(Todo todo);
    Task UpdateTodoAsync(Todo todo);
    Task DeleteTodoAsync(int id);
    Task<IEnumerable<SubTask?>> GetSubTasksForTodoAsync(int todoId);
    Task AddSubTaskToTodoAsync(int todoId, SubTask subTask);
}