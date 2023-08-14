namespace SportsComplexWebAPI.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; }
        public List<Group> Groups { get; set; }
        public List<Training> Trainings { get; set; }
        public List<CoachContact> CoachContacts { get; set; }
    }
}
