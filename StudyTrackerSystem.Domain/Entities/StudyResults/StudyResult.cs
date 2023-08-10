using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Subjects;

namespace StudyTrackerSystem.Domain.Entities.StudyResults;

public class StudyResult : AudiTable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int Ball { get; set; }
}
