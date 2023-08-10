using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Payments;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Payments;

public class PaymentRepository:Repository<Payment>,IPaymentRepository
{
    private readonly AppDbContext appDbContext;
    public PaymentRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<Payment> GetAllWithStudentAsync()
    {
        return appDbContext.Payments.Include(t => t.Student).AsQueryable();
    }

    public async Task<Payment> GetByIdWithStudentAsync(long Id)
    {
        return await appDbContext.Payments.Include(t => t.Student).FirstOrDefaultAsync(t => t.Id == Id);

    }
}
