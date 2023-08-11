using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

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
        var students = unitOfWork.StudentRepository.GetAllWithGroupAsync();
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
        var student = await unitOfWork.StudentRepository.GetByIdWithGroupAsync(id);
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

        var mappedStudent = mapper.Map(dto, student);

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

    public async Task<Response<bool>> GetAttendance(long groupId)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(groupId);
        if (group is null)
        {
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };
        }
        var students = await unitOfWork.StudentRepository.GetAllWithGroupAsync().ToListAsync();

        if (students is null)
        {
            return new Response<bool>()
            {
                StatusCode = 400,
                Message = "No students found in the group",
                Data = false
            };
        }

        Console.WriteLine("\tFirst Name\t\tLast Name");
        int cnt = 1;

        foreach (var student in students)
        {
            Console.WriteLine(cnt + " " + student.FirstName + " " + student.LastName);
            cnt++;
        }
        Console.Write("Mark an absent student: ");

        int select = int.Parse(Console.ReadLine());

        var student2 = students.ElementAt(select - 1);
        student2.Attendance = false;
        unitOfWork.StudentRepository.Update(student2);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<StudyResultResultDto>>> GetTopPerformers(long groupId, int count)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(groupId);
        if (group is null)
        {
            return new Response<IEnumerable<StudyResultResultDto>>()
            {
                StatusCode = 404,
                Message = "Group not found",
                Data = null
            };
        }

        var studyResults = await unitOfWork.StudyResultRepository.GetAll()
        .Include(sr => sr.Student)
        .Include(sr => sr.Subject)
        .Where(sr => sr.Student.GroupId == groupId)
        .OrderByDescending(sr => sr.Student.Attendance) // O'qitishga borish davomati bo'yicha saralash
        .ThenByDescending(sr => sr.Ball) // Baholar bo'yicha saralash
        .Take(count)
        .ToListAsync();

        var result = new List<StudyResultResultDto>();
        foreach (var student in studyResults)
        {
            var map = mapper.Map<StudyResultResultDto>(student);
            result.Add(map);
        }
        return new Response<IEnumerable<StudyResultResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
