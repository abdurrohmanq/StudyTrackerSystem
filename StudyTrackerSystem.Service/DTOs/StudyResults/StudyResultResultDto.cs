using StudyTrackerSystem.Service.DTOs.Students;

namespace StudyTrackerSystem.Service.DTOs.StudyResults;

public class StudyResultResultDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public int Ball { get; set; }
    public StudentResultDto StudentResultDto { get; set; }
}
