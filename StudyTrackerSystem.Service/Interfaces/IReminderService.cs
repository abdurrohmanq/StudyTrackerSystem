using StudyTrackerSystem.Service.DTOs.Reminders;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface IReminderService
{
    Task<Response<ReminderResultDto>> CreateAsync(ReminderCreationDto dto);
    Task<Response<ReminderResultDto>> UpdateAsync(ReminderUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<ReminderResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<ReminderResultDto>>> GetAllAsync();
}
