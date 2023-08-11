using StudyTrackerSystem.Domain.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.DTOs.Students;

public class StudentCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Attendance { get; set; } = true;
    public long GroupId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
