

using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Update;

internal class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitofWork _unitofWork;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository, IUnitofWork unitofWork)
    {
        _taskRepository = taskRepository;
        _unitofWork = unitofWork;
    }
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskByIdAsync(request.TaskId);

        if (task == null)
        {
            throw new ArgumentException("task not found");
        }

        task.Name = request.Name;
        task.Description = request.Description; 
        task.DueDate = request.DueDate;

        await _taskRepository.UpdateTaskAsync(task);
        await _unitofWork.SaveAsync(cancellationToken);
    }
}
