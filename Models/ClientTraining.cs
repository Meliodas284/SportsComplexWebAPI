namespace SportsComplexWebAPI.Models
{
    public class ClientTraining
    {
        public int Id { get; set; }
        public Training Training { get; set; } = new Training();
        public int TrainingId { get; set; }
        public ClientSeasonTicket ClientSeasonTicket { get; set; } = new ClientSeasonTicket();
        public int ClientSeasonTicketId { get; set; }
        public TrainingVisiting Visiting { get; set; } = TrainingVisiting.NotAttend;

    }
}
