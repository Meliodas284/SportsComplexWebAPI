namespace SportsComplexWebAPI.Models
{
    public class ClientTraining
    {
        public int Id { get; set; }
        public Training Training { get; set; }
        public int TrainingId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ClientSeasonTicket ClientSeasonTicket { get; set; }
        public int ClientSeasonTicketId { get; set; }
        public TrainingVisiting Visiting { get; set; } = TrainingVisiting.NotAttend;

    }
}
