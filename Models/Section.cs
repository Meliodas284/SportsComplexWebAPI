namespace SportsComplexWebAPI.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Gym> Gyms { get; set; } = new List<Gym>();
        public List<Coach> Coaches { get; set; } = new List<Coach>();
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; } = new List<ClientSeasonTicket>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
}
