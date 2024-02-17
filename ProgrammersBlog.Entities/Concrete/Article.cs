using ProgrammersBlog.Shared.Entities.Abstract;
using System;
namespace ProgrammersBlog.Entities.Concrete
{

    public class Article : EntityBase, IEntity
    {
        public int id;

        public String title { get; set; }
        public String content { get; set; }
        public String thumbnail { get; set; }//resmin yolu
        public DateTime Date { get; set; }
        public int ViewsCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public String seoDescreption { get; set; }
        public String seoTags { get; set; }
        public String seoAouther { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int userID { get; set; }
        public User user { get; set; }


    }
}
