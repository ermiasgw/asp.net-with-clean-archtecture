
using MediatR;

namespace Application.Tasks.Create;

public record CreateTaskCommand(
    string Name,
    string Description,
    DateTime DueDate) : IRequest;
