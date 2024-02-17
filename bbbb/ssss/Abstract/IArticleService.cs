using programmersBlog.Entities.Concrete;
using programmersBlog.Entities.Dtos;
using programmersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IResult> Add(ArticleAddDto articleAddto, string createdByName);
        Task<IResult> Updat(ArticleUpdatDto articleUpdatto, string modifiedByName);
        Task<IResult> Delete(int articleId, string modifiedByName);
        Task<IResult> HardDelete(int articleId);
        Task<IDataResult<ArticleDto>> Get(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryId);
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActice();
        Task<IDataResult<ArticleListDto>> GetAllByNoneDeleted();


    }
}
