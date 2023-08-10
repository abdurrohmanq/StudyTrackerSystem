using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PaymentService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<PaymentResultDto>> CreateAsync(PaymentCreationDto dto)
    {

        var mappedPayment = mapper.Map<Payment>(dto);

        await unitOfWork.PaymentRepository.CreateAsync(mappedPayment);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<PaymentResultDto>(mappedPayment);

        return new Response<PaymentResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);
        if (payment is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.PaymentRepository.Delete(payment);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<PaymentResultDto>>> GetAllAsync()
    {
        var payments = unitOfWork.PaymentRepository.GetAll();
        var result = new List<PaymentResultDto>();

        foreach (var payment in payments)
        {
            var map = mapper.Map<PaymentResultDto>(payment);
            result.Add(map);
        }

        return new Response<IEnumerable<PaymentResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<PaymentResultDto>> GetAsync(long id)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);
        if (payment is null)
            return new Response<PaymentResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<PaymentResultDto>(payment);

        return new Response<PaymentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<PaymentResultDto>> UpdateAsync(PaymentUpdateDto dto)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(dto.Id);
        if (payment is null)
            return new Response<PaymentResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedPayment = mapper.Map(dto, payment);

        unitOfWork.PaymentRepository.Update(mappedPayment);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<PaymentResultDto>(mappedPayment);

        return new Response<PaymentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
