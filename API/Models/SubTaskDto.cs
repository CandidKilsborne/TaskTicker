using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class SubTaskDto
{
    public int Id { get; set; }

    [MaxLength(250)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Details { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    public void Complete()
    {
        throw new NotImplementedException();
    }
}