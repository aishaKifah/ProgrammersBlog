using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleDto : DtoGetBase
    {
        public Article ArticleDto_ { get; set; }

    }
}
