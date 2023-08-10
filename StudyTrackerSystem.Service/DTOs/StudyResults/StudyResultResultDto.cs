using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Subjects;

namespace StudyTrackerSystem.Service.DTOs.StudyResults;

public class StudyResultResultDto
{
    public long Id { get; set; }
    public int Ball { get; set; }

    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
}
