using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Reminders;

namespace StudyTrackerSystem.Data.IRepositories.Reminders;

public interface IReminderRepository : IRepository<Reminder>
{
    IQueryable<Reminder> GetAllWithAsync();
    Task<Reminder> GetByIdWithAsync(long Id);
}
