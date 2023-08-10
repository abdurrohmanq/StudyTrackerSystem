using StudyTrackerSystem.Service.DTOs.Teachers;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface ITeacherService
{
    Task<Response<TeacherResultDto>> CreateAsync(TeacherCreationDto dto);
    Task<Response<TeacherResultDto>> UpdateAsync(TeacherUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<TeacherResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<TeacherResultDto>>> GetAllAsync();
}
