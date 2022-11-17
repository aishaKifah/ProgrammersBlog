using programamersBlog.Shared.Data.Abstract;
using programmersBlog.Entities.Concrete;

namespace programmersBlog.Data.Abstract
{
    public interface IArticleRepo : IEntityRepo<Article>
    {
    }
}
