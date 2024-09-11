using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskContext _context;

    public TaskController(TaskContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    [HttpPost]
    public async Task<ActionResult<Task>> CreateTask(Task task)
    {
        task.CreatedAt = DateTime.UtcNow; // Define CreatedAt
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
