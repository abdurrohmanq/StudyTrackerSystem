using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;

namespace StudyTrackerSystem.Domain.Entities.Reminders;

public class Reminder : AudiTable
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}
