namespace SportsComplexWebAPI.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Section Section { get; set; } = new Section();
        public int SectionId { get; set; }
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; } = new List<ClientSeasonTicket>();
        public List<Group> Groups { get; set; } = new List<Group>();
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<CoachContact> CoachContacts { get; set; } = new List<CoachContact>();
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
