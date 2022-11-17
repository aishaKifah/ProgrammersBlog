using programamersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace programmersBlog.Entities.Concrete
{

    public class Article : EntityBase, IEntity
    {
        public int id;

        public String tilte { get; set; }
        public String content { get; set; }
        public String thumbnail { get; set; }//resmin yolu
        public DateTime Date { get; set; }
        public int  viewsCount { get; set; }
        public int commentsCount { get; set; }
        public String seoDescreption { get; set; }
        public String seoTags { get; set; }
        public String seoAouther { get; set; }
        public ICollection<Comment> comments { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }

        public int userID { get; set; }
        public User user { get; set; }
    }
}
