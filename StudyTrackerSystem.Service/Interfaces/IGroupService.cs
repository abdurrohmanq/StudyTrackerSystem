using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface IGroupService
{
    Task<Response<GroupResultDto>> CreateAsync(GroupCreationDto dto);
    Task<Response<GroupResultDto>> UpdateAsync(GroupUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<GroupResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<GroupResultDto>>> GetAllAsync();
}
