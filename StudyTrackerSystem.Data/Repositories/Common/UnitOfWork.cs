using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.IRepositories.Groups;
using StudyTrackerSystem.Data.IRepositories.Payments;
using StudyTrackerSystem.Data.IRepositories.Reminders;
using StudyTrackerSystem.Data.IRepositories.Students;
using StudyTrackerSystem.Data.IRepositories.StudyResults;
using StudyTrackerSystem.Data.IRepositories.Subjects;
using StudyTrackerSystem.Data.IRepositories.Teachers;
using StudyTrackerSystem.Data.IRepositories.TextBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork()
    {
        
    }
    public IStudentRepository StudyRepository { get;}

    public ITeacherRepository TeacherRepository => throw new NotImplementedException();

    public IGroupRepository GroupRepository => throw new NotImplementedException();

    public IPaymentRepository Payment => throw new NotImplementedException();

    public ISubjectRepository SubjectRepository => throw new NotImplementedException();

    public ITextBookRepository TextBookRepository => throw new NotImplementedException();

    public IReminderRepository ReminderRepository => throw new NotImplementedException();

    public IStudyResultRepository StudyResultRepository => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}
