using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class SubLevelTodo
{
    [Key]
    public int Id { get; set; }

    public string? Task { get; set; }

    public string? Details { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }
}