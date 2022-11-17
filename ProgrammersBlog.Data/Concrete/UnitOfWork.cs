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
        private EfArticleRepo articleRepo;
        private EfcategoryRepo categoryRepo;
        private EfCommentRepo commentRepo;
        private EfRoleRepo roleRepo;
        private EfUserRepo userRepo;
        public IArticleRepo aticles => articleRepo ?? new EfArticleRepo(_context);
        public ICategoryRepo categories => categoryRepo ?? new EfcategoryRepo(_context);
        public IRoleRepo roles => roleRepo ?? new EfRoleRepo(_context);
        public ICommentRepo comments => new EfCommentRepo(_context);
        public IUserRepo users => new EfUserRepo(_context);
        public void Dispose()
        {
            throw new NotImplementedException();
        }

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
