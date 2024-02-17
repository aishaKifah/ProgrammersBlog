using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> ArticleListDto_ { get; set; }

    }
}
