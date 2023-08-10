using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface IStudyResultService
{
    Task<Response<StudyResultResultDto>> CreateAsync(StudyResultCreationDto dto);
    Task<Response<StudyResultResultDto>> UpdateAsync(StudyResultUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<StudyResultResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<StudyResultResultDto>>> GetAllAsync();
}
