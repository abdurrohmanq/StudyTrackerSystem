using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Teachers;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Teachers;

public class TeacherRepository : Repository<Teacher>,ITeacherRepository
{
    private readonly AppDbContext appDbContext;
    public TeacherRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<Teacher> GetByEmail(string email)
    {
        return await appDbContext.Teachers.FirstOrDefaultAsync(t => t.Email.Equals(email));
    }
}
