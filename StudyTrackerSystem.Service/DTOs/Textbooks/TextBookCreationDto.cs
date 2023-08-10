using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.DTOs.Textbooks;

public class TextBookCreationDto
{
    public string Name { get; set; }
    public long SubjectId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
