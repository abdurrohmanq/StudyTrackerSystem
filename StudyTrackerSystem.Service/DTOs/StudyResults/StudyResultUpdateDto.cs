namespace StudyTrackerSystem.Service.DTOs.StudyResults;

public class StudyResultUpdateDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public int Ball { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
