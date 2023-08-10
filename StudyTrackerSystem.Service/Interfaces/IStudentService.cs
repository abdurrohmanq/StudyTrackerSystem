using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.DTOs.Subjects;
using StudyTrackerSystem.Service.DTOs.Textbooks;
using StudyTrackerSystem.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.Interfaces;

public interface IStudentService
{
    Task<Response<StudentResultDto>> CreateAsync(StudentCreationDto dto);
    Task<Response<StudentResultDto>> UpdateAsync(StudentUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<StudentResultDto>> GetAsync(long id);
    Task<Response<bool>> GetAttendance(long groupId);

    Task<Response<IEnumerable<StudentResultDto>>> GetAllAsync();
}
