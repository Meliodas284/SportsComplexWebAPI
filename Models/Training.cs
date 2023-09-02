namespace SportsComplexWebAPI.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Duration { get; set; }
        public string? Notes { get; set; }
        public Gym Gym { get; set; } = new Gym();
        public int? GymId { get; set; }
        public Coach Coach { get; set; } = new Coach();
        public int? CoachId { get; set; }
        public Section Section { get; set; } = new Section();
        public int? SectionId { get; set; }
        public Group Group { get; set; } = new Group();
        public int? GroupId { get; set; }
        public List<ClientTraining> ClientTrainings { get; set; } = new List<ClientTraining>();
    }
}
