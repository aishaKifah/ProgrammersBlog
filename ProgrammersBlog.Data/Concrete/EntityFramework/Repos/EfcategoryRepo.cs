using Microsoft.EntityFrameworkCore;
using programmersBlog.Data.Abstract;
using programmersBlog.Entities.Concrete;
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
    }
}
