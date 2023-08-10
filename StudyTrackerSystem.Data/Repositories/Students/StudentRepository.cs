using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Students;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Students;

public class StudentRepository:Repository<Student>,IStudentRepository
{
    private readonly AppDbContext appDbContext;
    public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
}
