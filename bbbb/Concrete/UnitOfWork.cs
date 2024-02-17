using programmersBlog.Data.Abstract;
using programmersBlog.Data.Concrete.EntityFramework.Contexts;
using programmersBlog.Data.Concrete.EntityFramework.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Concrete
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
   
        public IArticleRepo aticles => ArticleRepo ?? new EfArticleRepo(_context);
        public ICategoryRepo categories => categoryRepo ?? new EfcategoryRepo(_context);
       
        public ICommentRepo comments => new EfCommentRepo(_context);

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
