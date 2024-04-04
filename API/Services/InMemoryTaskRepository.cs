using API.Entities;

namespace API.Services;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<Todo> _todos = new()
    {
        new Todo("First todo")
        {
            Id = 1,
            IsCompleted = false,
            Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eros in cursus turpis massa tincidunt dui ut ornare. Vitae congue mauris rhoncus aenean. Mauris nunc congue nisi vitae. Purus in massa tempor nec feugiat nisl pretium fusce. Pellentesque adipiscing commodo elit at imperdiet dui accumsan sit. Arcu cursus vitae congue mauris rhoncus aenean vel. Leo duis ut diam quam. Dictum at tempor commodo ullamcorper a lacus vestibulum sed. Tellus pellentesque eu tincidunt tortor aliquam nulla facilisi cras. Ullamcorper sit amet risus nullam eget felis eget nunc. Integer vitae justo eget magna fermentum iaculis.",
            DueDate = DateTime.Now.AddDays(7),
            SubTasks = new List<SubTask>
            {
                new SubTask("First sub task")
                {
                    Id = 1,
                    IsCompleted = false,
                    DueDate = DateTime.Now.AddDays(3)
                },
                new SubTask("Second sub task")
                {
                    Id = 2,
                    IsCompleted = true,
                    DueDate = DateTime.Now.AddDays(5)
                }
            }
        },
        new Todo("Second todo")
        {
            Id = 2,
            IsCompleted = true,
            DueDate = DateTime.Now.AddDays(3),
            SubTasks = new List<SubTask>
            {
                new SubTask("Third sub task") { Id = 3, IsCompleted = false }
            }
        },
        new Todo("Third todo")
        {
            Id = 3,
            IsCompleted = false,
            DueDate = DateTime.Now.AddDays(5),
            SubTasks = new List<SubTask>
            {
                new SubTask("Fourth sub task") { Id = 4, IsCompleted = false },
                new SubTask("Fifth sub task") { Id = 5, IsCompleted = false }
            }
        }
    };

    public async Task<IEnumerable<Todo>> GetTodosAsync()
    {
        return await Task.FromResult(_todos.AsEnumerable());
    }

    public async Task<Todo?> GetTodoAsync(int id)
    {
        return await Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));
    }

    public async Task<IEnumerable<Todo>> GetTodosByDueDateAsync(DateTime dueDate)
    {
        return await Task.FromResult(_todos.Where(t => t.DueDate == dueDate));
    }

    public async Task<IEnumerable<Todo>> GetTodosByCompletedAsync(bool isCompleted)
    {
        return await Task.FromResult(_todos.Where(t => t.IsCompleted == isCompleted));
    }

    public async Task<bool> DoesTodoExistAsync(int id)
    {
        return await Task.FromResult(_todos.Any(t => t.Id == id));
    }

    public async Task SetTodoCompletedAsync(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            todo.IsCompleted = true;
        }

        await Task.CompletedTask;
    }

    public async Task CreateTodoAsync(Todo todo)
    {
        todo.Id = _todos.Max(t => t.Id) + 1;

        _todos.Add(todo);

        await Task.CompletedTask;
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        int index = _todos.FindIndex(t => t.Id == todo.Id);
        _todos[index] = todo;

        await Task.CompletedTask;
    }

    public async Task DeleteTodoAsync(int id)
    {
        _todos.RemoveAll(t => t.Id == id);

        await Task.CompletedTask;
    }

    public async Task<IEnumerable<SubTask?>> GetSubTasksForTodoAsync(int todoId)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == todoId);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }

        return await Task.FromResult(todo.SubTasks);
    }

    public async Task AddSubTaskToTodoAsync(int todoId, SubTask subTask)
    {
        var todo = await GetTodoAsync(todoId);
        if (todo != null)
        {
            todo.SubTasks.Add(subTask);
        }
    }

    public async Task<int> GetNextTodoIdAsync()
    {
        return await Task.FromResult(_todos.Max(t => t.Id) + 1);
    }
}