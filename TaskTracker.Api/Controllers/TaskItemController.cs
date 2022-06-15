using Microsoft.AspNetCore.Mvc;
using TaskTracker.Api.Entities;
using TaskTracker.Api.Repositories.Contracts;


namespace TaskTracker.Api.Controllers
{
    [ApiController]
    [Route("/tasks")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemRepository taskItemRepository;

        private readonly ILogger<TaskItemController> _logger;

        private const string ERROR_MESSAGE = "Error retrieving data from the database";

        public TaskItemController(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }


        [HttpPost]
        public async Task<IActionResult> AddTaskItem(TaskItem taskItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await taskItemRepository.AddTaskItem(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { taskItem.Id }, taskItem);
        }


        [HttpGet]
        public async Task<IActionResult> GetTaskItems()
        {
            try
            {
                var taskItems = await taskItemRepository.GetTaskItems();
                if (taskItems == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(taskItems);

                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ERROR_MESSAGE);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTaskItem(int id)
        {
            try
            {
                var taskItem = await taskItemRepository.GetTaskItem(id);
                if (taskItem == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(taskItem);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ERROR_MESSAGE);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItem taskItemToUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var taskItem = await taskItemRepository.UpdateTaskItem(id, taskItemToUpdate);

                if (taskItem == null)
                {
                    return NotFound();
                }
                return Ok(taskItem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ERROR_MESSAGE);
            }


        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            try
            {
                await taskItemRepository.DeleteTaskItem(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ERROR_MESSAGE);
            }
        }



    }
}
