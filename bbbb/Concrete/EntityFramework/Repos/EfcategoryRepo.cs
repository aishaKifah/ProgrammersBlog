using Microsoft.EntityFrameworkCore;
using programmersBlog.Data.Abstract;
using programmersBlog.Data.Concrete.EntityFramework.Contexts;
using programmersBlog.Entities.Concrete;
using programmersBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Concrete.EntityFramework.Repos
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
