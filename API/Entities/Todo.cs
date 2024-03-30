namespace API.Entities;

public class Todo
{
    public int Id { get; set; }
    public string? Task { get; set; }
    public string? Details { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}