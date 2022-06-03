using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Dtos
{
    public class TaskUpdateDto
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public bool Done { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        [Required]
        private TimeSpan resolutionDuration;
        public TimeSpan ResolutionDuration { get { 
                return Created - DateTimeOffset.Now; 
            
            } 
            set {
                resolutionDuration =
                    Created - DateTimeOffset.Now;
            } 
        }
    }

}
