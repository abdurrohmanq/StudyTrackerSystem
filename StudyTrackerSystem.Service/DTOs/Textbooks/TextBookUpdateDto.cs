namespace StudyTrackerSystem.Service.DTOs.Textbooks;

public class TextBookUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long SubjectId { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
