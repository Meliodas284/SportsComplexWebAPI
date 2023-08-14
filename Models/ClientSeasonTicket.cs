namespace SportsComplexWebAPI.Models
{
    public class ClientSeasonTicket
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int VisitsNumber { get; set; }
        public SeasonTicket SeasonTicket { get; set; }
        public int SeasonTicketId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Coach Coach { get; set; }
        public int? CoachId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public Gym Gym { get; set; }
        public int GymId { get; set; }
        public Group Group { get; set; }
        public int? GroupId { get; set; }
        public List<ClientTraining> ClientTrainings { get; set; }
    }
}
