using TaskManager.API.Models;

namespace TaskManager.API.Data
{
    public interface ITaskRepo
    {
        Task SaveChanges();
        Task<TaskOne> GetTaskById(Guid id);
        Task<IEnumerable<TaskOne>> GetAllTasks();
        Task CreateTask(TaskOne task);
        void DeleteTask(TaskOne task);
    }
}
