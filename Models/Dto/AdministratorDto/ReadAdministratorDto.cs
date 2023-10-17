namespace SportsComplexWebAPI.Models.Dto.AdministratorDto
{
    public class ReadAdministratorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
