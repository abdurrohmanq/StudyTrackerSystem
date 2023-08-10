using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.IRepositories.Teachers;

public interface ITeacherRepository:IRepository<Teacher>
{
    Task<Teacher> GetByEmail(string email); 
}
