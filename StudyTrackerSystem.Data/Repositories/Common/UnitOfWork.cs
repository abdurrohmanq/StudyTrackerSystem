using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.IRepositories.Groups;
using StudyTrackerSystem.Data.IRepositories.Payments;
using StudyTrackerSystem.Data.IRepositories.Reminders;
using StudyTrackerSystem.Data.IRepositories.Students;
using StudyTrackerSystem.Data.IRepositories.StudyResults;
using StudyTrackerSystem.Data.IRepositories.Subjects;
using StudyTrackerSystem.Data.IRepositories.Teachers;
using StudyTrackerSystem.Data.IRepositories.TextBooks;
using StudyTrackerSystem.Data.Repositories.Groups;
using StudyTrackerSystem.Data.Repositories.Payments;
using StudyTrackerSystem.Data.Repositories.Reminders;
using StudyTrackerSystem.Data.Repositories.Students;
using StudyTrackerSystem.Data.Repositories.StudyResults;
using StudyTrackerSystem.Data.Repositories.Subjects;
using StudyTrackerSystem.Data.Repositories.Teachers;
using StudyTrackerSystem.Data.Repositories.TextBooks;

namespace StudyTrackerSystem.Data.Repositories.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork()
    {
        appDbContext = new AppDbContext();
        StudentRepository = new StudentRepository(appDbContext);
        TeacherRepository = new TeacherRepository(appDbContext);
        GroupRepository = new GroupRepository(appDbContext);
        PaymentRepository = new PaymentRepository(appDbContext);
        SubjectRepository = new SubjectRepository(appDbContext);
        TextBookRepository = new TextBookRepository(appDbContext);
        ReminderRepository = new ReminderRepository(appDbContext);
        StudyResultRepository = new StudyResultRepository(appDbContext);
    }
    public IStudentRepository StudentRepository { get; }

    public ITeacherRepository TeacherRepository { get; }

    public IGroupRepository GroupRepository { get; }

    public IPaymentRepository PaymentRepository { get; }

    public ISubjectRepository SubjectRepository { get; }

    public ITextBookRepository TextBookRepository { get; }

    public IReminderRepository ReminderRepository { get; }

    public IStudyResultRepository StudyResultRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveChanges()
    {
        await appDbContext.SaveChangesAsync();
    }
}
