using StudyTrackerSystem.Domain.Entities.Subjects;

namespace StudyTrackerSystem.Service.DTOs.Textbooks;

public class TextBookResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
}
