using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using programamersBlog.Shared.Entities.Abstract;

namespace programmersBlog.Entities.Concrete
{
    public class Role: EntityBase, IEntity
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection <User> users { get; set; }


    }
}
