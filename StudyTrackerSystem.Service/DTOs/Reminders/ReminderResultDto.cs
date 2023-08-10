namespace StudyTrackerSystem.Service.DTOs.Reminders;

public class ReminderResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long StudentId { get; set; }
    public long TeacherId { get; set; }
}
