using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class SubTaskCreationDto
{
    [MaxLength(250)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Details { get; set; }

    public DateTime? DueDate { get; set; }
}