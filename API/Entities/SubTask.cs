using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class SubTask : ITask
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(250)]
    public string? Title { get; set; }

    [MaxLength(500)]
    public string? Details { get; set; }

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; } = false;

    [ForeignKey("TodoId")]
    public Todo? Todo { get; set; }
    public int TodoId { get; set; }

    public SubTask(string title)
    {
        Title = title;
    }
}