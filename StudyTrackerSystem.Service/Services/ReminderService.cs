using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.TextBooks;
using StudyTrackerSystem.Service.DTOs.Textbooks;
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
    public async Task<Response<TextBookResultDto>> CreateAsync(TextBookCreationDto dto)
    {

        var mappedTextBook = mapper.Map<TextBook>(dto);

        await unitOfWork.TextBookRepository.CreateAsync(mappedTextBook);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<TextBookResultDto>(mappedTextBook);

        return new Response<TextBookResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var textBook = await unitOfWork.TextBookRepository.GetByIdAsync(id);
        if (textBook is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.TextBookRepository.Delete(textBook);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<TextBookResultDto>>> GetAllAsync()
    {
        var textBooks = unitOfWork.TextBookRepository.GetAll();
        var result = new List<TextBookResultDto>();

        foreach (var textBook in textBooks)
        {
            var map = mapper.Map<TextBookResultDto>(textBook);
            result.Add(map);
        }

        return new Response<IEnumerable<TextBookResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<TextBookResultDto>> GetAsync(long id)
    {
        var textBook = await unitOfWork.TextBookRepository.GetByIdAsync(id);
        if (textBook is null)
            return new Response<TextBookResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<TextBookResultDto>(textBook);

        return new Response<TextBookResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<TextBookResultDto>> UpdateAsync(TextBookUpdateDto dto)
    {
        var textBook = await unitOfWork.TextBookRepository.GetByIdAsync(dto.Id);
        if (textBook is null)
            return new Response<TextBookResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedTextBook = mapper.Map(dto, textBook);

        unitOfWork.TextBookRepository.Update(mappedTextBook);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<TextBookResultDto>(mappedTextBook);

        return new Response<TextBookResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
