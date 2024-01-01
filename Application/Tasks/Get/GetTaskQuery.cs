

using Domain.Entities;
using MediatR;

namespace Application.Tasks.Get;

public record GetTaskQuery(Guid TaskId) : IRequest<TaskEntity>;
