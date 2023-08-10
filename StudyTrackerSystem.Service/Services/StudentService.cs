using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Service.DTOs.Students;
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

        var students = group.Students.ToList();
        if (students.Count == 0)
        {
            return new Response<bool>()
            {
                StatusCode = 400,
                Message = "No students found in the group",
                Data = false
            };
        }

        Console.WriteLine("\tFirst Name\t\t\tLast Name");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i].FirstName}\t\t{students[i].LastName}");
        }

        Console.Write("Mark an absent student: ");
        if (!int.TryParse(Console.ReadLine(), out int select) || select < 1 || select > students.Count)
        {
            return new Response<bool>()
            {
                StatusCode = 400,
                Message = "Invalid student selection",
                Data = false
            };
        }

        var student2 = students[select - 1];
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


}
