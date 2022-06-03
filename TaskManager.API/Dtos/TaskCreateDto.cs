using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Dtos
{
    public class TaskCreateDto
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public bool Done { get; set; } = false;
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

    }
}
