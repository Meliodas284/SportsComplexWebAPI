namespace SportsComplexWebAPI.Models
{
    public class ClientSeasonTicket
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int VisitsNumber { get; set; }
        public SeasonTicket SeasonTicket { get; set; } = new SeasonTicket();
        public int SeasonTicketId { get; set; }
        public Client Client { get; set; } = new Client();
        public int ClientId { get; set; }
        public Coach Coach { get; set; } = new Coach();
        public int? CoachId { get; set; }
        public Section Section { get; set; } = new Section();
        public int SectionId { get; set; }
        public Group Group { get; set; } = new Group();
        public int? GroupId { get; set; }
        public List<ClientTraining> ClientTrainings { get; set; } = new List<ClientTraining>();
    }
}
