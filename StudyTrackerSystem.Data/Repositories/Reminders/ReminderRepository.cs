using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Reminders;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Reminders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Reminders;

public class ReminderRepository:Repository<Reminder>,IReminderRepository
{
    private readonly AppDbContext appDbContext;
    public ReminderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<Reminder> GetAllWithAsync()
    {
        return appDbContext.Reminders.Include(t => t.Student).Include(t => t.Teacher).AsQueryable();
    }

    public async Task<Reminder> GetByIdWithAsync(long Id)
    {
        return await appDbContext.Reminders.Include(t => t.Student).Include(t => t.Teacher).FirstOrDefaultAsync(t => t.Id == Id);

    }
}
