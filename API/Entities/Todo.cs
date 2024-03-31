namespace API.Entities;

public abstract class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }

    public Todo(string title)
    {
        Title = title;
        IsCompleted = false;
    }

    public abstract void Complete();
}