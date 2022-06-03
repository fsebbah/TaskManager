using Microsoft.EntityFrameworkCore;
using TaskManager.API.Models;

namespace TaskManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // AMbiguité entre le Models.task et System.Threading.Tasks.Task
        // Et j'ai perdu 2 heures à comprendre pourquoi la migration ne se faisait pas.
        public DbSet<TaskOne> Tasks => Set<TaskOne>();

    }
}
