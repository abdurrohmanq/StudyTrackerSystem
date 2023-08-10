namespace StudyTrackerSystem.Service.DTOs.Reminders;

public class ReminderUpdateDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long StudentId { get; set; }
    public long TeacherId { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
