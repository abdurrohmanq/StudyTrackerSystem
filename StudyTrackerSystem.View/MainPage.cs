using StudyTrackerSystem.View.Groups;
using StudyTrackerSystem.View.Payments;
using StudyTrackerSystem.View.Reminders;
using StudyTrackerSystem.View.Students;
using StudyTrackerSystem.View.StudyResults;
using StudyTrackerSystem.View.Subjects;
using StudyTrackerSystem.View.Teachers;
using StudyTrackerSystem.View.TextBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.View;

public class MainPage
{
    StudentServiceView studentServiceView = new StudentServiceView();
    TeacherServiceView TeacherServiceView = new TeacherServiceView();
    GroupServiceView groupServiceView = new GroupServiceView();
    SubjectServiceView subjectServiceView = new SubjectServiceView();   
    TextBookServiceView textBookServiceView = new TextBookServiceView();
    ReminderServiceView ReminderServiceView = new ReminderServiceView();
    StudyResultView studyResultView = new StudyResultView();
    PaymentServiceView PaymentServiceView = new PaymentServiceView();
    public void MainView()
    {
        Console.WriteLine("\t\t\t~~~~~~~MENU~~~~~~~~");
        Console.WriteLine(@"
                           1. Group
                           2. Student
                           3. Teacher
                           4. Subject
                           5. TextBook
                           6. Reminder
                           7. Study Result
                           8. Payment
                           0. Exit");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Group();
                break;
            case 2:
                Student();
                break;
            case 3:
                Teacher();
                break;
            case 4:
                Subject();
                break;
            case 5:
                TextBook();
                break;
            case 6:
                Reminder();
                break;
            case 7:
                StudyResult();
                break;
            case 8:
                Payment();
                break;
            case 0:
                return;
            default:
                MainView();
                break;
        }
    }
    public void Group()
    {
        Console.WriteLine("---------- Group ----------");
        Console.WriteLine("1. Create\n" +
            "2. Delete\n" +
            "3. Update\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                groupServiceView.Create();
                break;
            case 2:
                groupServiceView.Delete();
                break;
            case 3:
                groupServiceView.Update();
                break;
            case 4:
                groupServiceView.Get();
                break;
            case 5:
                groupServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
        }
        Group();
    }

    public void Student()
    {
        Console.WriteLine("---------- Student ----------");
        Console.WriteLine("1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                studentServiceView.Create();
                break;
            case 2:
                studentServiceView.Update();
                break;
            case 3:
                studentServiceView.Delete();
                break;
            case 4:
                studentServiceView.Get();
                break;
            case 5:
                studentServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                Student();
                break;
        }
        Student();
    }

    public void Teacher()
    {
        Console.WriteLine("---------- Teacher ----------");
        Console.WriteLine("1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                TeacherServiceView.Create();
                break;
            case 2:
                TeacherServiceView.Update();
                break;
            case 3:
                TeacherServiceView.Delete();
                break;
            case 4:
                TeacherServiceView.Get();
                break;
            case 5:
                TeacherServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                Teacher();
                break;
        }
        Teacher();
    }


    public void Subject()
    {
        Console.WriteLine("---------- Subject ----------");
        Console.WriteLine(
            "1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                subjectServiceView.Create();
                break;
            case 2:
                subjectServiceView.Update();
                break;
            case 3:
                subjectServiceView.Delete();
                break;
            case 4:
                subjectServiceView.Get();
                break;
            case 5:
                subjectServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                Subject();
                break;
        }
        Subject();
    }


    public void TextBook()
    {
        Console.WriteLine("---------- TextBook ----------");
        Console.WriteLine("1. Create\n" +
            "2. Delete\n" +
            "3. Update\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                textBookServiceView.Create();
                break;
            case 2:
                textBookServiceView.Delete();
                break;
            case 3:
                textBookServiceView.Update();
                break;
            case 4:
                groupServiceView.Get();
                break;
            case 5:
                groupServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
        }
        TextBook();
    }

    public void StudyResult()
    {
        Console.WriteLine("---------- StudyResult ----------");
        Console.WriteLine("1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                studyResultView.Create();
                break;
            case 2:
                studyResultView.Update();
                break;
            case 3:
                studyResultView.Delete();
                break;
            case 4:
                studyResultView.Get();
                break;
            case 5:
                studyResultView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                StudyResult();
                break;
        }
        StudyResult();
    }

    public void Reminder()
    {
        Console.WriteLine("---------- Teacher ----------");
        Console.WriteLine("1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                ReminderServiceView.Create();
                break;
            case 2:
                ReminderServiceView.Update();
                break;
            case 3:
                ReminderServiceView.Delete();
                break;
            case 4:
                ReminderServiceView.Get();
                break;
            case 5:
                ReminderServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                Reminder();
                break;
        }
        Reminder();
    }


    public void Payment()
    {
        Console.WriteLine("---------- Payment ----------");
        Console.WriteLine(
            "1. Create\n" +
            "2. Update\n" +
            "3. Delete\n" +
            "4. Get\n" +
            "5. GetAll\n" +
            "0. Back");
        Console.Write(">>> ");

        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                PaymentServiceView.Create();
                break;
            case 2:
                PaymentServiceView.Update();
                break;
            case 3:
                PaymentServiceView.Delete();
                break;
            case 4:
                PaymentServiceView.Get();
                break;
            case 5:
                PaymentServiceView.GetAll();
                break;
            case 0:
                MainView();
                break;
            default:
                Payment();
                break;
        }
        Payment();
    }
}
