using StudyTrackerSystem.Service.DTOs.Subjects;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface ISubjectService
{
    Task<Response<SubjectResultDto>> CreateAsync(SubjectCreationDto dto);
    Task<Response<SubjectResultDto>> UpdateAsync(SubjectUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<SubjectResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<SubjectResultDto>>> GetAllAsync();
}
