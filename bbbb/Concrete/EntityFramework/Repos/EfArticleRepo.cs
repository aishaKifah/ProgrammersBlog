using programmersBlog.Data.Abstract;
using programmersBlog.Entities.Concrete;

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using programmersBlog.Shared.Data.Concrete.EntityFramework;

namespace programmersBlog.Data.Concrete.EntityFramework.Repos
{
   public  class EfArticleRepo : EfEntityRepoBase<Article>, IArticleRepo
    {
        public EfArticleRepo(DbContext context) : base(context) { 
        }
    }
}
