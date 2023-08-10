using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.DTOs.Subjects;

namespace StudyTrackerSystem.Service.DTOs.StudyResults;

public class StudyResultResultDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public int Ball { get; set; }
    public StudentResultDto StudentResultDto { get; set; }
    public SubjectResultDto SubjectResultDto { get; set; }
}
