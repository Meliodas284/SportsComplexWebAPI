namespace SportsComplexWebAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Coach Coach { get; set; }
        public int CoachId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public List<Training> Trainings { get; set; }
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; }
    }
}
