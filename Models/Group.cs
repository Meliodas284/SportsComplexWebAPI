namespace SportsComplexWebAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Coach Coach { get; set; } = new Coach();
        public int CoachId { get; set; }
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; } = new List<ClientSeasonTicket>();
    }
}
