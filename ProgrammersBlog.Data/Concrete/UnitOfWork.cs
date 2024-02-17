using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repos;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammerBlogContext _context;
        public UnitOfWork(ProgrammerBlogContext context)
        {
            _context = context;
        }
        private EfArticleRepo ArticleRepo;
        private EfcategoryRepo categoryRepo;
        private EfCommentRepo commentRepo;

        public IArticleRepo Articles => ArticleRepo ?? new EfArticleRepo(_context);
        public ICategoryRepo Categories => categoryRepo ?? new EfcategoryRepo(_context);

        public ICommentRepo Comments => new EfCommentRepo(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> saveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
