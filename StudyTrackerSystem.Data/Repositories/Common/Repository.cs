using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Domain.Common;

namespace StudyTrackerSystem.Data.Repositories.Common;

public class Repository<T> : IRepository<T> where T : AudiTable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return dbSet.AsNoTracking().AsQueryable();
    }

    public Task<T> GetByIdAsync(long? id)
        => dbSet.FirstOrDefaultAsync(x => x.Id == id);

    public void Update(T entity)
    {
        appDbContext.Entry(entity).State = EntityState.Modified;
    }
}
