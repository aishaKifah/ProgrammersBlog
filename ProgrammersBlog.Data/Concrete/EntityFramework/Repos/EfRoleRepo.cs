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
    public class EfRoleRepo : EfEntityRepoBase<Role>, IRoleRepo
    {
        public EfRoleRepo(DbContext context) : base(context) { }

    }
}
