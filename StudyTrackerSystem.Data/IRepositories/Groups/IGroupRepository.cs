using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Entities.Groups;

namespace StudyTrackerSystem.Data.IRepositories.Groups;

public interface IGroupRepository : IRepository<Group>
{
    Task<Group> GetByIdWithStudentsAsync(long groupId);

}
