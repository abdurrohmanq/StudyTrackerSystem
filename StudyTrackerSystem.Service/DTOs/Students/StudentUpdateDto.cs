using StudyTrackerSystem.Domain.Entities.Groups;
using System.Text.RegularExpressions;

namespace StudyTrackerSystem.Service.DTOs.Students;

public class StudentUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Attendance { get; set; }
    public long GroupId { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
public class StudentResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Attendance { get; set; }
    public GroupResultDto { get; set;}
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

}
