namespace SportsComplexWebAPI.Models
{
    public class CoachContact
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public Coach Coach { get; set; } = new Coach();
        public int CoachId { get; set; }
    }
}
