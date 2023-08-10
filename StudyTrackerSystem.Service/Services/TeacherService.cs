using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Teachers;
using StudyTrackerSystem.Service.DTOs.Teachers;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TeacherService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<TeacherResultDto>> CreateAsync(TeacherCreationDto dto)
    {
        var teacher = await unitOfWork.TeacherRepository.GetByEmail(dto.Email);
        if (teacher is not null)
            return new Response<TeacherResultDto>()
            {
                StatusCode = 403,
                Message = "This already exist",
                Data = null
            };

        var mappedTeacher = mapper.Map<Teacher>(dto);

        await unitOfWork.TeacherRepository.CreateAsync(mappedTeacher);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<TeacherResultDto>(mappedTeacher);

        return new Response<TeacherResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var teacher = await unitOfWork.TeacherRepository.GetByIdAsync(id);
        if (teacher is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.TeacherRepository.Delete(teacher);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<TeacherResultDto>>> GetAllAsync()
    {
        var teachers = unitOfWork.TeacherRepository.GetAll();
        var result = new List<TeacherResultDto>();

        foreach (var teacher in teachers)
        {
            var map = mapper.Map<TeacherResultDto>(teacher);
            result.Add(map);
        }

        return new Response<IEnumerable<TeacherResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<TeacherResultDto>> GetAsync(long id)
    {
        var teacher = await unitOfWork.TeacherRepository.GetByIdAsync(id);
        if (teacher is null)
            return new Response<TeacherResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<TeacherResultDto>(teacher);

        return new Response<TeacherResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<TeacherResultDto>> UpdateAsync(TeacherUpdateDto dto)
    {
        var teacher = await unitOfWork.TeacherRepository.GetByIdAsync(dto.Id);
        if (teacher is null)
            return new Response<TeacherResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedTeacher = mapper.Map(dto, teacher);

        unitOfWork.TeacherRepository.Update(mappedTeacher);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<TeacherResultDto>(mappedTeacher);

        return new Response<TeacherResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
