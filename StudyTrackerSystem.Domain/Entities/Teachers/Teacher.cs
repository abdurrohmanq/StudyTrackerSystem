using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Domain.Entities.Reminders;

namespace StudyTrackerSystem.Domain.Entities.Teachers;

public class Teacher : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public ICollection<Reminder> Reminders { get; set; }
}
