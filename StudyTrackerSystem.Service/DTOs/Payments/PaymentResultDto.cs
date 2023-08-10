using StudyTrackerSystem.Domain.Entities.Students;

namespace StudyTrackerSystem.Service.DTOs.Payments;

public class PaymentResultDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}
