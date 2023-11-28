using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.CoachDto;

namespace SportsComplexWebAPI.Services.CoachService
{
	public interface ICoachService
	{
		public Task<ResponseAPI<List<GetCoachDto>>> GetAll();
		public Task<ResponseAPI<GetCoachDto>> Get(int id);
		public Task<ResponseAPI<GetCoachDto>> Register(RegisterCoachDto request);
		public Task<ResponseAPI<GetCoachDto>> Update(UpdateCoachDto request);
		public Task<ResponseAPI<GetCoachDto>> Delete(int id);
	}
}
