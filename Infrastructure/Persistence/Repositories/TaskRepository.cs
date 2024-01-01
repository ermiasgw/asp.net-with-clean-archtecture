

using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

internal class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TaskRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<TaskEntity> GetTaskByIdAsync(Guid taskId)
    {
        return await _dbContext.Tasks.FindAsync(taskId);
    }

    public async Task CreateTaskAsync(TaskEntity task)
    {
        _dbContext.Tasks.Add(task);
    }

    public async Task UpdateTaskAsync(TaskEntity task)
    {
        _dbContext.Entry(task).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(TaskEntity task)
    {
        _dbContext.Tasks.Remove(task);
    }
}
