

using MediatR;

namespace Application.Tasks.Update;

public record UpdateTaskCommand(
    Guid TaskId,
    string Name,
    string Description,
    DateTime DueDate) : IRequest;

public record UpdateTaskRequest(
    string Name,
    string Description,
    DateTime DueDate);

