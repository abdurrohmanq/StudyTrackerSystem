using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.DTOs.Reminders;

public class ReminderCreationDto
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long? StudentId { get; set; }
    public long? TeacherId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
