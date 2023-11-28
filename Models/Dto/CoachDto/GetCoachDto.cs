﻿namespace SportsComplexWebAPI.Models.Dto.CoachDto
{
    public class GetCoachDto
    {
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public Section Section { get; set; }
    }
}
