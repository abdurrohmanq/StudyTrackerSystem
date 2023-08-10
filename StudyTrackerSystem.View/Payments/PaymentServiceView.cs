using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.Services;

namespace StudyTrackerSystem.View.Payments;

public class PaymentServiceView
{

    PaymentCreationDto creationDto = new PaymentCreationDto();
    PaymentUpdateDto updateDto = new PaymentUpdateDto();
    PaymentService paymentService = new PaymentService();

    public async void Create()
    {
        Console.Write("Enter Student Id: ");
        creationDto.StudentId = long.Parse(Console.ReadLine());
        Console.Write("Enter Amount: ");
        creationDto.Amount = decimal.Parse(Console.ReadLine());
        Console.Write("Enter Date: ");
        creationDto.Date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine((await paymentService.CreateAsync(creationDto)).Message);
    }

    public async void Delete()
    {
        Console.Write("Enter Payment id: ");
        long id = long.Parse(Console.ReadLine());

        Console.WriteLine((await paymentService.DeleteAsync(id)).Message);
    }

    public async void Update()
    {
        Console.Write("Enter Payment Id: ");
        updateDto.Id = long.Parse(Console.ReadLine());
        Console.Write("Enter Student Id: ");
        updateDto.StudentId = long.Parse(Console.ReadLine());
        Console.Write("Enter Amount: ");
        updateDto.Amount = decimal.Parse(Console.ReadLine());
        Console.Write("Enter Date: ");
        updateDto.Date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine((await paymentService.UpdateAsync(updateDto)).Message);
    }

    public async void Get()
    {
        Console.Write("Enter Payment  Id: ");
        long id = long.Parse(Console.ReadLine());

        var result = (await paymentService.GetAsync(id)).Data;

        if (result != null)
        {
            Console.WriteLine(result.Student.FirstName + "  " + result.Amount + " " + result.Date);
        }
        else
        {
            Console.WriteLine((await paymentService.GetAsync(id)).Message);
        }
    }

    public async void GetAll()
    {
        var result = (await paymentService.GetAllAsync()).Data;

        if (result != null)
        {
            foreach (var item in result)
            {
                Console.WriteLine(item.Student.FirstName + "  " + item.Amount + " " + item.Date);

            }
        }
        else
        {
            Console.WriteLine((await paymentService.GetAllAsync()).Message);
        }
    }
}