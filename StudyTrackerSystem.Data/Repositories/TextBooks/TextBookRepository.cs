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
}
