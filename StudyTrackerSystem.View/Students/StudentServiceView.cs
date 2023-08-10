using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.Students;

public class StudentServiceView
{
    StudentCreationDto creationDto = new StudentCreationDto();
    StudentUpdateDto updateDto = new StudentUpdateDto();
    StudentService studentService = new StudentService();

    public async void Create()
    {
        Console.Write("Enter FirstName: ");
        creationDto.FirstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        creationDto.LastName = Console.ReadLine();
        Console.Write("Enter Address: ");
        creationDto.Address = Console.ReadLine();
        Console.Write("Enter BirthDay: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime reminderDate))
        {
            creationDto.DateOfBirth = reminderDate;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        Console.Write("Enter Group Id: ");
        creationDto.GroupId = long.Parse(Console.ReadLine());

        Console.WriteLine((await studentService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter ID: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await studentService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Id: ");
        updateDto.Id = long.Parse(Console.ReadLine());
        Console.Write("Enter FirstName: ");
        updateDto.FirstName = Console.ReadLine();
        Console.Write("Enter LastName: ");
        updateDto.LastName = Console.ReadLine();
        Console.Write("Enter Address: ");
        updateDto.Address = Console.ReadLine();
        Console.Write("Enter BirthDay: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime reminderDate))
        {
            updateDto.DateOfBirth = reminderDate;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        Console.Write("Enter Group Id: ");
        updateDto.GroupId = long.Parse(Console.ReadLine());

        Console.WriteLine((await studentService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter ID: ");
        long id = long.Parse(Console.ReadLine());

        var result = (await studentService.GetAsync(id)).Data;
        if (result is not null)
        {
            if (result.Group is not null)
            {
                Console.WriteLine($"FirstName: {result.FirstName} LastName: {result.LastName} Address: {result.Address} Group: {result.Group.Name}");
            }
            else
            {
                Console.WriteLine($"FirstName: {result.FirstName} LastName: {result.LastName} Address: {result.Address} Group: No group Assigned");
            }
        }
        else
            Console.WriteLine((await studentService.GetAsync(id)).Message);
    }

    public async void GetAll()
    {
        var students = (await studentService.GetAllAsync()).Data;
        if (students.Any())
        {
            foreach (var student in students)
            {
                if(student.Group is not null)
                   Console.WriteLine($"FirstName: {student.FirstName} LastName: {student.LastName} Address: {student.Address} Group: {student.Group.Name}");
                else
                    Console.WriteLine($"FirstName: {student.FirstName} LastName: {student.LastName} Address: {student.Address} Group: Np Group Assigned");
            }
        }
        else
            Console.WriteLine((await studentService.GetAllAsync()).Message);
    }

    public async void GetAttendance()
    {
        Console.WriteLine("Enter Group id: ");
        long id = long.Parse(Console.ReadLine());
        
        Console.WriteLine((await studentService.GetAttendance(id)).Message);    
    }
}
