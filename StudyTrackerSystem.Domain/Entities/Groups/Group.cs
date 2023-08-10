using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;

namespace StudyTrackerSystem.Domain.Entities.Groups;

public class Group : AudiTable
{
    public string Name { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
    public ICollection<Student> Students { get; set; }
}
