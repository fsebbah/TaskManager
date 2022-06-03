using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models;

namespace TaskManager.API.Data
{
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDbContext _context;

        public TaskRepo(AppDbContext context)
        {
            _context = context;

        }
        public async Task CreateTask(TaskOne task)
        {
            if(task == null)
                throw new ArgumentNullException(nameof(task));

            await _context.AddAsync(task);
        }

        public void DeleteTask(TaskOne task)
        {
            if(task == null)
                throw new ArgumentNullException(nameof(task));

            _context.Remove(task);

        }

        public async Task<IEnumerable<TaskOne>> GetAllTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskOne?> GetTaskById(Guid id)
        {

            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
