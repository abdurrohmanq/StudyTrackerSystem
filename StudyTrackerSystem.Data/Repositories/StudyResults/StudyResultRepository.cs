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
}
