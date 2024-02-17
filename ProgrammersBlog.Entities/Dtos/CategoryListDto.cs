using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> CategoryListDto_ { get; set; }
    }
}
