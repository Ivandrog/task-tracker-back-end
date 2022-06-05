using TaskTracker.Api.Entities;

namespace TaskTracker.Api.Repositories.Contracts
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetTaskItems();
        Task<TaskItem?> GetTaskItem(int id);
        Task<TaskItem?> AddTaskItem(TaskItem taskItem);
        Task<TaskItem?> UpdateTaskItem(int id,TaskItem taskItem);
        Task<TaskItem> DeleteTaskItem(int id);
    }
}
