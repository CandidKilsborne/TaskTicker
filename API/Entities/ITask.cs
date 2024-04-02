namespace API.Entities;

public interface ITask
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Details { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
}