using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repos
{
    public class EfcategoryRepo : EfEntityRepoBase<Category>, ICategoryRepo

    {
        public EfcategoryRepo(DbContext context) : base(context) { }
        public async Task<Category> GetById(int categoryId)
        // the follow code are written to show how we get benifit of defining dbContext as protected type 
        {
            return await ProgrammerBlogContext.Categories.SingleOrDefaultAsync(c => c.id == categoryId);
        }
        private ProgrammerBlogContext ProgrammerBlogContext
        {
            get
            {
                return _context as ProgrammerBlogContext;
            }
        }


    }
}
