using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Shared.Data.Abstract;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public String picture { get; set; }


        public ICollection<Article> Articles { get; set; }


    }
}
