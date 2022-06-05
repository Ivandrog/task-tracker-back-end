using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Data;
using TaskTracker.Api.Entities;
using TaskTracker.Api.Repositories.Contracts;

namespace TaskTracker.Api.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {

        private readonly TaskItemDbContext taskItemDbContext;

        public TaskItemRepository(TaskItemDbContext taskItemDbContext)
        {
            this.taskItemDbContext = taskItemDbContext;
        }

        public async Task<TaskItem?> AddTaskItem(TaskItem taskItem)
        {
            var result = await taskItemDbContext.AddAsync(taskItem);
            await taskItemDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskItem?> GetTaskItem(int id)
        {
            var taskItem = await taskItemDbContext.TaskItems.SingleOrDefaultAsync(x => x.Id == id);
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItems()
        {
            var taskItems = await this.taskItemDbContext.TaskItems.ToListAsync();
           
            return taskItems;
        }

        public async Task<TaskItem?> UpdateTaskItem(int id, TaskItem taskItemToUpdate)
        {
            var taskItem = await taskItemDbContext.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                taskItem.Text = taskItemToUpdate.Text;
                taskItem.IsReminder = taskItemToUpdate.IsReminder;
                taskItem.day = taskItemToUpdate.day;
                await taskItemDbContext.SaveChangesAsync();
            }

            return taskItem;
        }

        public async Task<TaskItem> DeleteTaskItem(int id)
        {
            var taskItemToDelete = await taskItemDbContext.TaskItems.FindAsync(id);

            if(taskItemToDelete != null)
            {
                taskItemDbContext.Remove(taskItemToDelete);
                await taskItemDbContext.SaveChangesAsync();
            }
            return taskItemToDelete;
        }
    }
}
