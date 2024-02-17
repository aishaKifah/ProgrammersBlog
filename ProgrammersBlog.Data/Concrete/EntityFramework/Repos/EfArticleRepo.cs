using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Data.Concrete.EntityFramework;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Repos
{
    public class EfArticleRepo : EfEntityRepoBase<Article>, IArticleRepo
    {
        public EfArticleRepo(DbContext context) : base(context)
        {
        }
    }
}
