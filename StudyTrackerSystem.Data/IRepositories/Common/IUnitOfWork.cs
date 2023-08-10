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

namespace StudyTrackerSystem.Data.IRepositories.Common;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository StudyRepository { get; }
    ITeacherRepository TeacherRepository { get; }
    IGroupRepository GroupRepository { get; }
    IPaymentRepository Payment { get; }
    ISubjectRepository SubjectRepository { get; }
    ITextBookRepository TextBookRepository { get; }
    IReminderRepository ReminderRepository { get; }
    IStudyResultRepository StudyResultRepository { get; }
    Task SaveChanges();
}
