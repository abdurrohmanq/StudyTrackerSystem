using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.Reminders;
using StudyTrackerSystem.Domain.Entities.StudyResults;

namespace StudyTrackerSystem.Domain.Entities.Students;

public class Student : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Attendance { get; set; }
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Reminder> Reminders { get; set; }
    public ICollection<StudyResult> StudyResults { get; set; }
}
