namespace SportsComplexWebAPI.Dtos.Administrator
{
    public class PutAdminDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
