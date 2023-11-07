using SportsComplexWebAPI.Models.Dto.CoachDto;

namespace SportsComplexWebAPI.Models.Dto.GroupDto
{
	public class GetGroupDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
	}
}
