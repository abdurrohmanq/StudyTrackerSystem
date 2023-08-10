using StudyTrackerSystem.Service.DTOs.Subjects;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.Subjects;

public class SubjectServiceView
{
    SubjectCreationDto creationDto = new SubjectCreationDto();
    SubjectUpdateDto updateDto = new SubjectUpdateDto();
    SubjectService subjectService = new SubjectService();

    public async void Create()
    {
        Console.Write("Enter Name: ");
        creationDto.Name = Console.ReadLine();

        Console.WriteLine((await subjectService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter Id :");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await subjectService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Id :");
        updateDto.Id = long.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        updateDto.Name = Console.ReadLine();

        Console.WriteLine((await subjectService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter Id :");
        long id = long.Parse(Console.ReadLine());
        var result = (await subjectService.GetAsync(id)).Data;
        if (result != null)
            Console.WriteLine(result.Name);
        else
            Console.WriteLine((await subjectService.GetAsync(id)).Message);
    }

    public async void GetAll()
    {
        var subjects = (await subjectService.GetAllAsync()).Data;
        if(subjects != null)
            foreach (var subject in subjects)
                Console.WriteLine(subject.Name);
        else
        {
            Console.WriteLine((await subjectService.GetAllAsync()).Message);
        }
    }
}
