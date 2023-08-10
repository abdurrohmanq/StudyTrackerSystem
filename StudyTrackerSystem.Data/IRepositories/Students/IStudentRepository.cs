using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.IRepositories.Students;

public interface IStudentRepository : IRepository<Student>
{
    IQueryable<Student> GetAllWithGroupAsync();
    Task<Student> GetByIdWithGroupAsync(long Id);
}
