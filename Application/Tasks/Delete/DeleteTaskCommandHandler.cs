
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Delete;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitofWork _unitofWork;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository, IUnitofWork unitofWork)
    {
        _taskRepository = taskRepository;
        _unitofWork = unitofWork;
    }
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(request.TaskId);

        if (task == null)
        {
            throw new ArgumentException("there is no task with the specified id");
        }
        await _taskRepository.DeleteTaskAsync(task);
        await _unitofWork.SaveAsync(cancellationToken);
        return;
    }
}
