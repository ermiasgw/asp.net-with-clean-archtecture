

using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Get;

internal class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskEntity>>
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<IEnumerable<TaskEntity>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetAllTasksAsync();
    }
}
