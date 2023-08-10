using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.DTOs.Reminders;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.Reminders;

public class ReminderServiceView
{
    ReminderCreationDto creationDto = new ReminderCreationDto();
    ReminderUpdateDto updateDto = new ReminderUpdateDto();
    ReminderService remindService = new ReminderService();

    public async void Create()
    {
        Console.Write("Enter Remind Text: ");
        creationDto.Text = Console.ReadLine();
        Console.Write("Enter Reminder Date: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime reminderDate))
        {
            creationDto.Date = reminderDate;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        Console.Write("Enter Role (1 for Student, 2 for Teacher): ");
        if (int.TryParse(Console.ReadLine(), out int roleId))
        {
            if (roleId == 1)
            {
                Console.Write("Enter Student ID: ");
                if (long.TryParse(Console.ReadLine(), out long studentId))
                {
                    creationDto.StudentId = studentId;
                    creationDto.TeacherId = null;
                }
                else
                {
                    Console.WriteLine("Invalid Student ID.");
                    return;
                }
            }
            else if (roleId == 2)
            {
                Console.Write("Enter Teacher ID: ");
                if (long.TryParse(Console.ReadLine(), out long teacherId))
                {
                    creationDto.TeacherId = teacherId;
                    creationDto.StudentId = null;
                }
                else
                {
                    Console.WriteLine("Invalid Teacher ID.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Role ID.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid Role ID.");
            return;
        }

        Console.WriteLine((await remindService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter Payment id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await remindService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Remind Text: ");
        updateDto.Text = Console.ReadLine();
        Console.Write("Enter Reminder Date: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime reminderDate))
        {
            updateDto.Date = reminderDate;
        }
        else
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        Console.Write("Enter Role (1 for Student, 2 for Teacher): ");
        if (int.TryParse(Console.ReadLine(), out int roleId))
        {
            if (roleId == 1)
            {
                Console.Write("Enter Student ID: ");
                if (long.TryParse(Console.ReadLine(), out long studentId))
                {
                    updateDto.StudentId = studentId;
                }
                else
                {
                    Console.WriteLine("Invalid Student ID.");
                    return;
                }
            }
            else if (roleId == 2)
            {
                Console.Write("Enter Teacher ID: ");
                if (long.TryParse(Console.ReadLine(), out long teacherId))
                {
                    updateDto.TeacherId = teacherId;
                }
                else
                {
                    Console.WriteLine("Invalid Teacher ID.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid Role ID.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Invalid Role ID.");
            return;
        }
        Console.WriteLine((await remindService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter Remind Id: ");
        long id = long.Parse(Console.ReadLine());

        var response = (await remindService.GetAsync(id));

        if (response.Data is not null)
        {
            var result = response.Data;
            if (result.Student is not null)
                Console.WriteLine(result.Student.FirstName + "  " + result.Text + " " + result.Date);
            else if (result.Teacher is not null)
                Console.WriteLine(result.Teacher.FirstName + "  " + result.Text + " " + result.Date);
        }
        else
        {
            Console.WriteLine((await remindService.GetAsync(id)).Message);
        }
    }

    public async void GetAll()
    {
        var result = (await remindService.GetAllAsync()).Data;

        if (result != null)
        {
            foreach (var item in result)
            {
                if (item.StudentId != 0)
                {
                    Console.WriteLine("Student: " + item.Student.FirstName + " " + item.Student.LastName + " " + item.Text + "  " + item.Date);
                }
                else if (item.TeacherId != 0)
                {
                    Console.WriteLine("Teacher: " + item.Teacher.FirstName + " " + item.Teacher.LastName +" "+item.Text + " "+ item.Date);
                }
            }
        }
        else
        {
            Console.WriteLine((await remindService.GetAllAsync()).Message);
        }
    }
}