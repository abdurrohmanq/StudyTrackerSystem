using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.DTOs.StudyResults;

public class StudyResultCreationDto
{
    public long StudentId { get; set; }
    public long SubjectId { get; set; }
    public int Ball { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
