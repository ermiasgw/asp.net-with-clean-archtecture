

using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Get;

public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskEntity>
{
    private readonly ITaskRepository _taskRepository;

    public GetTaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskEntity> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetTaskByIdAsync(request.TaskId);
    }
}
