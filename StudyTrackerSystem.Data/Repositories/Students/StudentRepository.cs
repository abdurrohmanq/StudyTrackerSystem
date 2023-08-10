using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Students;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;
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

    public IQueryable<Student> GetAllWithGroupAsync()
    {
        return appDbContext.Students.Include(t => t.Group).AsQueryable();
    }

    public async Task<Student> GetByIdWithGroupAsync(long Id)
    {
        return await appDbContext.Students.Include(t => t.Group).FirstOrDefaultAsync(t => t.Id == Id);
    }
}
