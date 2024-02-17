using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
namespace ProgrammersBlog.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        public int id { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public ICollection<Article> Articles { get; set; }


    }
}
