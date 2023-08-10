using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Payments;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Payments;
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
}
