namespace TaskManager.API.Dtos
{
    public class TaskReadDto
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool Done { get; set; }
        public DateTimeOffset Created { get; set; }
        public TimeSpan ResolutionDuration { get; set; }

    }
}
