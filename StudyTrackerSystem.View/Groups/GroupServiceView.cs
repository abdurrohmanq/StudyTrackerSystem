using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View.Groups;

public class GroupServiceView
{
    GroupCreationDto creationDto = new GroupCreationDto();
    GroupUpdateDto updateDto = new GroupUpdateDto();
    GroupService groupService = new GroupService();

    public async void Create()
    {
        Console.Write("Enter Name: ");
        creationDto.Name = Console.ReadLine();

        Console.WriteLine((await groupService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter group id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await groupService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Id: ");
        long id = long.Parse(Console.ReadLine());

        Console.Write("Enter Name: ");
        updateDto.Name = Console.ReadLine();

        Console.WriteLine((await groupService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = (await groupService.GetAsync(id)).Data;

        if (result != null)
        {
            Console.WriteLine(result.Id + "  " + result.Name);
        }
        else 
        {
            Console.WriteLine((await groupService.GetAsync(id)).Message);
        }
    }

    public async void GetAll()
    {
        var result = (await groupService.GetAllAsync()).Data;

        if(result != null)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item.Id + "  " + item.Name);
            }
        }
        else
        {
            Console.WriteLine((await groupService.GetAllAsync()).Message);
        }
    }
}
