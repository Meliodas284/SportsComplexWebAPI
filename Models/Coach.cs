namespace SportsComplexWebAPI.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public List<Group> Groups { get; set; } = new();
    }
}
