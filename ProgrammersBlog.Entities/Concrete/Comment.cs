using ProgrammersBlog.Shared.Entities.Abstract;
using System;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        public int id;

        public String text { get; set; }
        public int articleId { get; set; }
        public Article article { get; set; }


    }
}
