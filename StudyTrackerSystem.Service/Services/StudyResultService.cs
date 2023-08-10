using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class StudyResultService : IStudyResultService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public StudyResultService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<StudyResultResultDto>> CreateAsync(StudyResultCreationDto dto)
    {
        var student = await unitOfWork.StudentRepository.GetByIdAsync(dto.StudentId);
        var subject = await unitOfWork.SubjectRepository.GetByIdAsync(dto.SubjectId);
        if (student == null|| subject == null)
            return new Response<StudyResultResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found"
            };


        var mappedStudyResult = mapper.Map<StudyResult>(dto);
        mappedStudyResult.Subject = subject;
        mappedStudyResult.Student = student;

        await unitOfWork.StudyResultRepository.CreateAsync(mappedStudyResult);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<StudyResultResultDto>(mappedStudyResult);

        return new Response<StudyResultResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var studyResult = await unitOfWork.StudyResultRepository.GetByIdAsync(id);
        if (studyResult is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.StudyResultRepository.Delete(studyResult);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<StudyResultResultDto>>> GetAllAsync()
    {
        var studyResults = unitOfWork.StudyResultRepository.GetAllWithAsync();
        var result = new List<StudyResultResultDto>();

        foreach (var studyResult in studyResults)
        {
            var map = mapper.Map<StudyResultResultDto>(studyResult);
            result.Add(map);
        }

        return new Response<IEnumerable<StudyResultResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<StudyResultResultDto>> GetAsync(long id)
    {
        var studyResult = await unitOfWork.StudyResultRepository.GetByIdWithAsync(id);
        if (studyResult is null)
            return new Response<StudyResultResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<StudyResultResultDto>(studyResult);

        return new Response<StudyResultResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    

    public async Task<Response<StudyResultResultDto>> UpdateAsync(StudyResultUpdateDto dto)
    {
        var studyResult = await unitOfWork.StudyResultRepository.GetByIdAsync(dto.Id);
        if (studyResult is null)
            return new Response<StudyResultResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedStudyResult = mapper.Map(dto, studyResult);

        unitOfWork.StudyResultRepository.Update(mappedStudyResult);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<StudyResultResultDto>(mappedStudyResult);

        return new Response<StudyResultResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
