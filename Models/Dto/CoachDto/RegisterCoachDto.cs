namespace SportsComplexWebAPI.Models.Dto.CoachDto
{
    public class RegisterCoachDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string SectionName { get; set; } = string.Empty;
    }
}
