using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Subjects;

namespace StudyTrackerSystem.Domain.Entities.TextBooks;

public class TextBook : AudiTable
{
    public string Name { get; set; }
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
}
