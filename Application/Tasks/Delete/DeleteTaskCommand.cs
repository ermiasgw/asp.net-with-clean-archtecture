
using MediatR;

namespace Application.Tasks.Delete;

public record DeleteTaskCommand(Guid TaskId) : IRequest;
