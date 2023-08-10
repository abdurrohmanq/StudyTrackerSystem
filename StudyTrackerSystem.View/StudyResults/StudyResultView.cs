using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.StudyResults;

public class StudyResultView
{
    StudyResultCreationDto creationDto = new StudyResultCreationDto();
    StudyResultUpdateDto updateDto = new StudyResultUpdateDto();
    StudyResultService studyResultService = new StudyResultService();

    public async void Create()
    {
        Console.Write("Enter Student Id: ");
        creationDto.StudentId = long.Parse(Console.ReadLine());
        Console.Write("Enter Subject Id: ");
        creationDto.SubjectId = long.Parse(Console.ReadLine());
        Console.Write("Enter Ball: ");
        creationDto.Ball = int.Parse(Console.ReadLine());

        Console.WriteLine((await studyResultService.CreateAsync(creationDto)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Study Result ID: ");
        updateDto.Id = long.Parse(Console.ReadLine());
        Console.Write("Enter Student Id: ");
        updateDto.StudentId = long.Parse(Console.ReadLine());
        Console.Write("Enter Subject Id: ");
        updateDto.SubjectId = long.Parse(Console.ReadLine());
        Console.Write("Enter Ball: ");
        updateDto.Ball = int.Parse(Console.ReadLine());

        Console.WriteLine((await studyResultService.UpdateAsync(updateDto)).Message);
    }

    public async void Delete()
    {
        Console.WriteLine("Enter Study Result ID: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await studyResultService.DeleteAsync(id)).Message);
    }

    public async void Get()
    {
        Console.WriteLine("Enter Study Result ID: ");
        long id = long.Parse(Console.ReadLine());
        var result = (await studyResultService.GetAsync(id)).Data;

        if (result != null)
        {
            if (result.Subject is not null && result.Student is not null)
                Console.WriteLine(result.Student.FirstName + " " + result.Student.LastName + " " + result.Subject.Name + " " + result.Ball);
            else
                Console.WriteLine("Student or Subject is Null");
        }
        else
        {
            Console.WriteLine((await studyResultService.GetAsync(id)).Message);
        }
    }

    public async void GetAll()
    {
        var StudyResults = (await studyResultService.GetAllAsync()).Data;
        if(StudyResults != null)
        {
            foreach (var StudyResult in StudyResults)
            {
                if (StudyResult.Student != null && StudyResult.Subject != null)
                {
                    Console.WriteLine(StudyResult.Student.FirstName + " " + StudyResult.Student.LastName + " " + StudyResult.Subject.Name + " " + StudyResult.Ball);
                }
                else
                    Console.WriteLine(StudyResult.Ball);
            }
        }
        else
        {
            Console.WriteLine((await studyResultService.GetAllAsync()).Message);
        }
    }
}
