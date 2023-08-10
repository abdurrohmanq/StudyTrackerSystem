using Microsoft.EntityFrameworkCore;
using StudyTrackerSystem.Data.Contexts;
using StudyTrackerSystem.Data.IRepositories.TextBooks;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.TextBooks;

namespace StudyTrackerSystem.Data.Repositories.TextBooks;

public class TextBookRepository : Repository<TextBook>, ITextBookRepository
{
    private readonly AppDbContext appDbContext;
    public TextBookRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<TextBook> GetAllWithSubjectAsync()
    {
        return appDbContext.TextBooks.Include(s => s.Subject).AsQueryable();

    }

    public async Task<TextBook> GetByIdWithSubjectAsync(long Id)
    {
        return await appDbContext.TextBooks.Include(t => t.Subject).FirstOrDefaultAsync(t => t.Id == Id);
    }
}
