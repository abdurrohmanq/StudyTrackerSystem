using StudyTrackerSystem.Domain.Common;
using StudyTrackerSystem.Domain.Entities.Students;

namespace StudyTrackerSystem.Domain.Entities.Payments;

public class Payment : AudiTable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}