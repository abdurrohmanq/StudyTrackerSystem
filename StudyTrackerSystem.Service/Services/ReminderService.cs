using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Reminders;
using StudyTrackerSystem.Service.DTOs.Reminders;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class ReminderService : IReminderService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ReminderService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<ReminderResultDto>> CreateAsync(ReminderCreationDto dto)
    {

        var mappedRemind = mapper.Map<Reminder>(dto);

        await unitOfWork.ReminderRepository.CreateAsync(mappedRemind);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<ReminderResultDto>(mappedRemind);

        return new Response<ReminderResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var remind = await unitOfWork.ReminderRepository.GetByIdAsync(id);
        if (remind is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.ReminderRepository.Delete(remind);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<ReminderResultDto>>> GetAllAsync()
    {
        var reminds = unitOfWork.ReminderRepository.GetAll();
        var result = new List<ReminderResultDto>();

        foreach (var remind in reminds)
        {
            var map = mapper.Map<ReminderResultDto>(remind);
            result.Add(map);
        }

        return new Response<IEnumerable<ReminderResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<ReminderResultDto>> GetAsync(long id)
    {
        var remind = await unitOfWork.ReminderRepository.GetByIdAsync(id);
        if (remind is null)
            return new Response<ReminderResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<ReminderResultDto>(remind);

        return new Response<ReminderResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<ReminderResultDto>> UpdateAsync(ReminderUpdateDto dto)
    {
        var remind = await unitOfWork.ReminderRepository.GetByIdAsync(dto.Id);
        if (remind is null)
            return new Response<ReminderResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedRemind = mapper.Map(dto, remind);

        unitOfWork.ReminderRepository.Update(mappedRemind);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<ReminderResultDto>(mappedRemind);

        return new Response<ReminderResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
