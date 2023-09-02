namespace SportsComplexWebAPI.Models
{
    public class SeasonTicket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SeasonTicketType Type { get; set; } = SeasonTicketType.OneTime;
        public int? AvailableVisits { get; set; }
        public int Price { get; set; }
        public List<ClientSeasonTicket> ClientSeasonTickets { get; set; } = new List<ClientSeasonTicket>();
    }
}
