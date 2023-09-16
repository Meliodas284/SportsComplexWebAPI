namespace SportsComplexWebAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; } = new List<ClientSeasonTicket>();
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
