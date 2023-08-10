using StudyTrackerSystem.Service.DTOs.Groups;

namespace StudyTrackerSystem.Service.DTOs.Teachers;

public class TeacherResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public GroupResultDto GroupResult { get; set; }
}

