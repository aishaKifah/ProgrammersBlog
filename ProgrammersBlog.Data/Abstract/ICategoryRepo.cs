using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using programmersBlog.Entities.Concrete;
using programamersBlog.Shared.Data.Abstract;
namespace programmersBlog.Data.Abstract
{
   public  interface ICategoryRepo : IEntityRepo<Category>
    {
    }
}
