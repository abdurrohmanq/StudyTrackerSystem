namespace StudyTrackerSystem.Service.DTOs.Groups;

public class GroupUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
