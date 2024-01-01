

using Domain.Entities;

namespace Domain.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity> GetTaskByIdAsync(Guid taskId);
    Task CreateTaskAsync(TaskEntity task);
    Task UpdateTaskAsync(TaskEntity task);
    Task DeleteTaskAsync(TaskEntity task);

}

