using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using programamersBlog.Shared.Entities.Abstract;
namespace programmersBlog.Entities.Concrete
{
    public class Category:EntityBase,IEntity
    {
        public int id;

        public  String Name { get; set; }
        public String Description { get; set; }
        public ICollection <Article> Articles { get; set; }


    }
}
