using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.IRepositories.StudyResults;

public interface IStudyResultRepository : IRepository<StudyResult>
{
    IQueryable<StudyResult> GetAllWithAsync();
    Task<StudyResult> GetByIdWithAsync(long Id);
}
