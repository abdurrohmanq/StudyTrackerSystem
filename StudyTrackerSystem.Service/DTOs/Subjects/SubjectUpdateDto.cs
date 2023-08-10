namespace StudyTrackerSystem.Service.DTOs.Subjects;

public class SubjectUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
