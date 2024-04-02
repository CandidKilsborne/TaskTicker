using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class TodoCreationDto
{
    [MaxLength(250)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Details { get; set; }

    public DateTime? DueDate { get; set; }

    public List<SubTaskCreationDto> SubTasks { get; set; } = new List<SubTaskCreationDto>();
}