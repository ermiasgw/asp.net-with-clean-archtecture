
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Tasks.Create;

internal class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitofWork _unitofWork;

    public CreateTaskCommandHandler(ITaskRepository taskRepository, IUnitofWork unitofWork)
    {
        _taskRepository = taskRepository;
        _unitofWork = unitofWork;
    }

    public async Task Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
        };

        await _taskRepository.CreateTaskAsync(task);
        await _unitofWork.SaveAsync(cancellationToken);

    }
}
