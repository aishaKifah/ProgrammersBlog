using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using programamersBlog.Shared.Entities.Abstract;

namespace programmersBlog.Entities.Concrete
{
    public class Comment : EntityBase,IEntity
    {
        public int id;

        public String text { get; set; }
        public int articleId { get; set; }
        public Article article { get; set; }


    }
}
