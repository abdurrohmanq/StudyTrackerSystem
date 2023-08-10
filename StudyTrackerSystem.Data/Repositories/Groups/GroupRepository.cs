using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Groups;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTrackerSystem.Data.Repositories.Groups;

public class GroupRepository : Repository<Group>,IGroupRepository
{
    private readonly AppDbContext appDbContext;
    public GroupRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
}
