using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface IArticleService
    {
        Task<IResult> AddAsync(ArticleAddDto articleAddto, string createdByName);
        Task<IResult> UpdateAsync(ArticleUpdatDto articleUpdatto, string modifiedByName);
        Task<IResult> DeleteAsync(int articleId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int articleId);
        Task<IDataResult<ArticleDto>> GetAsync(int articleId);
        Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryId);
        Task<IDataResult<ArticleListDto>> GetAllAsync();

        Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActiveAsync();

        Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAsync();

        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNoneDeletedAsync();

    }
}
