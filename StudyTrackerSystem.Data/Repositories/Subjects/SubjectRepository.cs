using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Subjects;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Subjects;

public class SubjectRepository:Repository<Subject>,ISubjectRepository
{
    private readonly AppDbContext appDbContext;
    public SubjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
}
