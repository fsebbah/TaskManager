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
                if(Done)
                    return Created - DateTimeOffset.Now;
                return resolutionDuration;
            } 
            set {
                resolutionDuration =
                    Created - DateTimeOffset.Now;
            } 
        }
    }

}
