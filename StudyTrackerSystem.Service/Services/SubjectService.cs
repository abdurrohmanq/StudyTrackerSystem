using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Domain.Entities.Subjects;
using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.DTOs.Subjects;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public SubjectService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<SubjectResultDto>> CreateAsync(SubjectCreationDto dto)
    {

        var mappedSubject = mapper.Map<Subject>(dto);

        await unitOfWork.SubjectRepository.CreateAsync(mappedSubject);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<SubjectResultDto>(mappedSubject);

        return new Response<SubjectResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var subject = await unitOfWork.SubjectRepository.GetByIdAsync(id);
        if (subject is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.SubjectRepository.Delete(subject);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<SubjectResultDto>>> GetAllAsync()
    {
        var subjects = unitOfWork.SubjectRepository.GetAll();
        var result = new List<SubjectResultDto>();

        foreach (var subject in subjects)
        {
            var map = mapper.Map<SubjectResultDto>(subject);
            result.Add(map);
        }

        return new Response<IEnumerable<SubjectResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<SubjectResultDto>> GetAsync(long id)
    {
        var subject = await unitOfWork.SubjectRepository.GetByIdAsync(id);
        if (subject is null)
            return new Response<SubjectResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<SubjectResultDto>(subject);

        return new Response<SubjectResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<SubjectResultDto>> UpdateAsync(SubjectUpdateDto dto)
    {
        var subject = await unitOfWork.SubjectRepository.GetByIdAsync(dto.Id);
        if (subject is null)
            return new Response<SubjectResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedSubject = mapper.Map(dto, subject);

        unitOfWork.SubjectRepository.Update(mappedSubject);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<SubjectResultDto>(mappedSubject);

        return new Response<SubjectResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
