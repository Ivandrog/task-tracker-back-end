using Microsoft.EntityFrameworkCore;
using TaskTracker.Api.Entities;

namespace TaskTracker.Api.Data
{
    public class TaskItemDbContext: DbContext
    {
        public TaskItemDbContext(DbContextOptions<TaskItemDbContext> options) : base(options)
        {

        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
