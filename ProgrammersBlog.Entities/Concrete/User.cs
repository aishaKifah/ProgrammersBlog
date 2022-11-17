using programamersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public String picture { get; set; }

        public int id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public byte[] passwordHash { get; set; }
        public String userName { get; set; }
        public int roleId { get; set; }
        public Role role { get; set; }
        public String discreption { get; set; }
        public ICollection<Article> articles { get; set; }


    }
}
