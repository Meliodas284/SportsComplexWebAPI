namespace SportsComplexWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public Administrator? Administrator { get; set; }
        public Client? Client { get; set; }
        public Coach? Coach { get; set; }

    }
}
