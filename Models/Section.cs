namespace SportsComplexWebAPI.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Gym> Gyms { get; set; }
        public List<Coach> Coaches { get; set; }
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; }
        public List<Group> Groups { get; set; }
        public List<Training> Trainings { get; set; }
    }
}
