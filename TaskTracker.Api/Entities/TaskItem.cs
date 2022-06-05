namespace TaskTracker.Api.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string? Text { get; set; }

        public string? day { get; set; }

        public bool IsReminder { get; set; }


    }
}
