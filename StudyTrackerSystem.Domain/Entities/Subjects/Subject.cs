using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using StudyTrackerSystem.Domain.Entities.TextBooks;

namespace StudyTrackerSystem.Domain.Entities.Subjects;

public class Subject : AudiTable
{
    public string Name { get; set; }
    public ICollection<TextBook> TextBooks { get; set; }
    public ICollection<StudyResult> StudyResults { get; set; }
}
