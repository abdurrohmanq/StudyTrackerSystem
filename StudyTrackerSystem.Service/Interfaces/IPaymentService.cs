using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.Helpers;

namespace StudyTrackerSystem.Service.Interfaces;

public interface IPaymentService
{
    Task<Response<PaymentResultDto>> CreateAsync(PaymentCreationDto dto);
    Task<Response<PaymentResultDto>> UpdateAsync(PaymentUpdateDto dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<PaymentResultDto>> GetAsync(long id);
    Task<Response<IEnumerable<PaymentResultDto>>> GetAllAsync();
}
