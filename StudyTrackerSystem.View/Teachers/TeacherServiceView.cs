using StudyTrackerSystem.Service.DTOs.Teachers;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.Teachers;

public class TeacherServiceView
{
    TeacherCreationDto creationDto = new TeacherCreationDto();
    TeacherUpdateDto updateDto = new TeacherUpdateDto();
    TeacherService teacherService = new TeacherService();
    public async void Create()
    {
        Console.Write("Enter FirstName: ");
        creationDto.FirstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        creationDto.LastName = Console.ReadLine();
        Console.Write("Enter Email: ");
        creationDto.Email = Console.ReadLine();
        Console.Write("Enter Password: ");
        creationDto.Password = Console.ReadLine();
        Console.Write("Enter Group Id: ");
        creationDto.GroupId = long.Parse(Console.ReadLine());

        Console.WriteLine((await teacherService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter ID: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await teacherService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Id: ");
        updateDto.Id = long.Parse(Console.ReadLine());
        Console.Write("Enter FirstName: ");
        updateDto.FirstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        updateDto.LastName = Console.ReadLine();
        Console.Write("Enter Email: ");
        updateDto.Email = Console.ReadLine();
        Console.Write("Enter Password: ");
        updateDto.Password = Console.ReadLine();
        Console.Write("Enter Group Id: ");
        updateDto.GroupId = long.Parse(Console.ReadLine());

        Console.WriteLine((await teacherService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter ID: ");
        long id = long.Parse(Console.ReadLine());

        var result = (await teacherService.GetAsync(id)).Data;
        if (result is not null)
            if (result.Group is not null)
            {
                Console.WriteLine($"FirstName: {result.FirstName} LastName: {result.LastName} Email: {result.Email} Group: {result.Group.Name}");
            }
            else
            {
                Console.WriteLine($"FirstName: {result.FirstName} LastName: {result.LastName} Email: {result.Email} Group: No Group Assigned");
            }
        else
            Console.WriteLine((await teacherService.GetAsync(id)).Message);
    }

    public async void GetAll()
    {
        var teachers = (await teacherService.GetAllAsync()).Data;
        if (teachers.Any())
        {
            foreach (var teacher in teachers)
            {
                if(teacher.Group != null)
                    Console.WriteLine($"FirstName: {teacher.FirstName} LastName: {teacher.LastName} Email:  {teacher.Email} Group: {teacher.Group.Name}");
                else
                    Console.WriteLine($"FirstName: {teacher.FirstName} LastName: {teacher.LastName} Email:  {teacher.Email} Group: No Group Assigned");
            }
        }
        else
            Console.WriteLine((await teacherService.GetAllAsync()).Message);
    }
}
