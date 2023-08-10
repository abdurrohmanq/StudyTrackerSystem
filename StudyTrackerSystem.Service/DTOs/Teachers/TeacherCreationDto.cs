using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.DTOs.Teachers;

public class TeacherCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long GroupId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

