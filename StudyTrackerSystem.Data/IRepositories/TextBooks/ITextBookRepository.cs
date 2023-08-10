using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.TextBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.IRepositories.TextBooks;

public interface ITextBookRepository:IRepository<TextBook>
{
    IQueryable<TextBook> GetAllWithSubjectAsync();
    Task<TextBook> GetByIdWithSubjectAsync(long Id);
}
