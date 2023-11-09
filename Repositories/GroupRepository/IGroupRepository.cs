using SportsComplexWebAPI.Models;
using SportsComplexWebAPI.Models.Dto.GroupDto;

namespace SportsComplexWebAPI.Repositories.GroupRepository
{
	public interface IGroupRepository
	{
		public Task<List<Group>> GetAll();
		public Task<Group?> GetById(int id);
		public Task<Group> Create(Group group);
		public Task<Group?> Update(UpdateGroupDto request);
		public Task<Group?> Delete(int id);
	}
}
