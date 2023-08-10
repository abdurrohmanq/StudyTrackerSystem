using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.StudyResults;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.StudyResults;

public class StudyResultRepository:Repository<StudyResult>,IStudyResultRepository
{
    private readonly AppDbContext appDbContext;
    public StudyResultRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<StudyResult> GetAllWithAsync()
    {
        return appDbContext.StudyResults.Include(t => t.Student).Include(s => s.Subject).AsQueryable();
    }

    public async Task<StudyResult> GetByIdWithAsync(long Id)
    {
        return await appDbContext.StudyResults.Include(t => t.Student).Include(t => t.Subject).FirstOrDefaultAsync(t => t.Id == Id);
    }
}
