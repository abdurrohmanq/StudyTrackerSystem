using StudyTrackerSystem.Service.DTOs.Textbooks;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface ITextBookService
{
    Task<Response<TextBookResultDto>> CreateAsync(TextBookCreationDto dto);
    Task<Response<TextBookResultDto>> UpdateAsync(TextBookUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<TextBookResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<TextBookResultDto>>> GetAllAsync();
}
