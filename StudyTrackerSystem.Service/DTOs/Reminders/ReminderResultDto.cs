using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;

namespace StudyTrackerSystem.Service.DTOs.Reminders;

public class ReminderResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}
