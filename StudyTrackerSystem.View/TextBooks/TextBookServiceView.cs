using StudyTrackerSystem.Service.DTOs.Textbooks;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.TextBooks;

public class TextBookServiceView
{
    TextBookCreationDto creationDto = new TextBookCreationDto();
    TextBookUpdateDto updateDto = new TextBookUpdateDto();
    TextBookService TextBookService = new TextBookService();

    public async void Create()
    {
        Console.Write("Enter Name: ");
        creationDto.Name = Console.ReadLine();
        Console.Write("Enter Subject ID: ");
        creationDto.SubjectId = long.Parse(Console.ReadLine());

        Console.WriteLine((await TextBookService.CreateAsync(creationDto)).Message);
    }
    public async void Delete()
    {
        Console.Write("Enter Id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await TextBookService.DeleteAsync(id)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = (await TextBookService.GetAsync(id)).Data;
        if (result != null)
        {
            if(result.Subject is not null)
                Console.WriteLine(result.Name + " " + result.Subject.Name);
            else
            {
                Console.WriteLine(result.Name);
            }
        }
        else
            Console.WriteLine((await TextBookService.GetAsync(id)).Message);
    }

    public async void GetAll()
    {
        var textBooks = (await  TextBookService.GetAllAsync()).Data;
        if (textBooks != null)
            foreach (var textBook in textBooks)
            {
                if (textBook.Subject != null)
                    Console.WriteLine(textBook.Name + " " + textBook.Subject.Name);
                else
                    Console.WriteLine(textBook.Name);
            }
        else
        {
            Console.WriteLine((await TextBookService.GetAllAsync()).Message);
        }
    }

    public async void Update()
    {
        Console.Write("Enter Id: ");
        updateDto.Id = long.Parse(Console.ReadLine());  
        Console.Write("Enter Name: ");
        updateDto.Name = Console.ReadLine();
        Console.Write("Enter Subject ID: ");
        updateDto.SubjectId = long.Parse(Console.ReadLine());

        Console.WriteLine((await TextBookService.UpdateAsync(updateDto)).Message);
    }
}
