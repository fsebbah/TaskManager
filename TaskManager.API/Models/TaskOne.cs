using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Models
{
    public class TaskOne
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public bool Done { get; set; }

        [Required]
        public DateTimeOffset Created { get; set; } 
        public TimeSpan ResolutionDuration { get; set; }


    }
}
