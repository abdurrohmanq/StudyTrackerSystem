namespace StudyTrackerSystem.Service.DTOs.Students;

public class StudentResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool Attendance { get; set; }
    public GroupResultDto { get; set;}
