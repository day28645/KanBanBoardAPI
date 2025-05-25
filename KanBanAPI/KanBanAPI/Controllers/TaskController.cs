using KanBanAPI.Data;
using KanBanAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanBanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetTasksAll")]
        public async Task<ActionResult<IEnumerable<KanbanTask>>> GetTasksAll()
        {
            return await _context.KanbanTasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetTasks(int id)
        {
            var task = _context.KanbanTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost("createTask")]
        public IActionResult CreateTask([FromBody] AddTaskRequest request)
        {
            var checkTask = _context.KanbanTasks.FirstOrDefault(c => c.taskName == request.taskName);
            if (checkTask != null)
            {
                ModelState.AddModelError("taskName", "This Task's Name is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var task = new KanbanTask
            {
                taskName = request.taskName,
                createDateTime = DateTime.Now,
                Id_Card = request.Id_Card
            };

            _context.KanbanTasks.Add(task);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] UpdateTaskRequest request)
        {
            var task = _context.KanbanTasks.Find(id);

            if (task == null)
            {
                return NotFound(new { message = "Task not found" });
            }

            task.taskName = request.taskName;

            var edit = new EditTask
            {
                Task_Id = id,
                Id_Card = request.Id_Card,
                editDateTime = DateTime.Now
            };

            _context.EditTasks.Add(edit);
            _context.SaveChanges();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.KanbanTasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.KanbanTasks.Remove(task);
            _context.SaveChanges();

            return Ok();
        }

    }
}
