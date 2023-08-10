using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Service.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public StudentService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<StudentResultDto>> CreateAsync(StudentCreationDto dto)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(dto.GroupId);
        if (group == null)
            return new Response<StudentResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found Group"
            };

        var mappedStudent = mapper.Map<Student>(dto);
        mappedStudent.Group = group;

        await unitOfWork.StudentRepository.CreateAsync(mappedStudent);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<StudentResultDto>(mappedStudent);

        return new Response<StudentResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var student = await unitOfWork.StudentRepository.GetByIdAsync(id);
        if (student is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.StudentRepository.Delete(student);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<StudentResultDto>>> GetAllAsync()
    {
        var students = unitOfWork.StudentRepository.GetAll();
        var result = new List<StudentResultDto>();

        foreach (var student in students)
        {
            var map = mapper.Map<StudentResultDto>(student);
            result.Add(map);
        }

        return new Response<IEnumerable<StudentResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<StudentResultDto>> GetAsync(long id)
    {
        var student = await unitOfWork.StudentRepository.GetByIdAsync(id);
        if (student is null)
            return new Response<StudentResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<StudentResultDto>(student);

        return new Response<StudentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<StudentResultDto>> UpdateAsync(StudentUpdateDto dto)
    {
        var student = await unitOfWork.StudentRepository.GetByIdAsync(dto.Id);
        if (student is null)
            return new Response<StudentResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedStudent = mapper.Map(dto,student);

        unitOfWork.StudentRepository.Update(mappedStudent);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<StudentResultDto>(mappedStudent);

        return new Response<StudentResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
