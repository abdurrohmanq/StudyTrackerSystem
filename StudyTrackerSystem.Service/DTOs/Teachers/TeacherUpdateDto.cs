namespace StudyTrackerSystem.Service.DTOs.Teachers;

public class TeacherUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long GroupId { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

