
namespace Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
}

