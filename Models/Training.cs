namespace SportsComplexWebAPI.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Notes { get; set; }
        public Gym Gym { get; set; }
        public int GymId { get; set; }
        public Coach Coach { get; set; }
        public int? CoachId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public List<ClientTraining> ClientTrainings { get; set; }
    }
}
