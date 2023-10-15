namespace SportsComplexWebAPI.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
