using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.IRepositories.Payments;

public interface IPaymentRepository:IRepository<Payment>
{
    IQueryable<Payment> GetAllWithStudentAsync();
    Task<Payment> GetByIdWithStudentAsync(long Id);
}
