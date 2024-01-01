

using Domain.Entities;
using MediatR;

namespace Application.Tasks.Get;

public record GetAllTaskQuery() : IRequest<IEnumerable<TaskEntity>>;

