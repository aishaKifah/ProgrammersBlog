using AutoMapper;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Utilities;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services
{
    public class ArticleManeger : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ArticleManeger(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IResult> AddAsync(ArticleAddDto articleAddto, string createdByName)
        {
            var articleRepeated = await _unitOfWork.Articles.AnyAsync(c => c.content.Equals(articleAddto.content));
            if (!articleRepeated)
            {
                var article = await _unitOfWork.Articles.AddAsync(
                        new Article
                        {
                            title = articleAddto.tilte,
                            content = articleAddto.content,
                            seoAouther = articleAddto.seoAouther,
                            seoDescreption = articleAddto.seoDescreption,
                            seoTags = articleAddto.seoTags,
                            Category = articleAddto.Category,
                            CategoryId = articleAddto.CategoryId,
                            thumbnail = articleAddto.thumbnail,
                            isActive = articleAddto.IsActive,
                            isDeleted = articleAddto.IsDeleted,
                            Date = DateTime.Now,
                            createdByname = createdByName,
                            modifiedByName = createdByName,
                            userID = 1

                        }
                        ).ContinueWith(t => _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.Add(articleAddto.tilte));


            }
            else
            {
                return new Result(ResultStatus.Error, Messages.Article.AlreadyExsit(articleAddto.tilte));
            }

        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var articlesCount = await _unitOfWork.Articles.CountAsync();
            if (articlesCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }

        public async Task<IDataResult<int>> CountByNoneDeletedAsync()
        {
            var articlesCount = await _unitOfWork.Articles.CountAsync(a=> !a.isDeleted);
            if (articlesCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, articlesCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }

        public async Task<IResult> DeleteAsync(int articleId, string modifiedByName)
        {
            var articleExsit = await _unitOfWork.Articles.AnyAsync(a => a.id == articleId);
            if (articleExsit)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.id == articleId);
                article.isDeleted = true;
                article.modifiedByName = modifiedByName;
                article.Date = DateTime.Now;
                await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.Delete(article.title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
        }

        public async Task<IDataResult<ArticleDto>> GetAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.id == articleId, a => a.user, a => a.Category);

            if (article != null)
            {
                return new ResultData<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    ArticleDto_ = article,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new ResultData<ArticleDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));

        }

        public async Task<IDataResult<ArticleListDto>> GetAllAsync()
        {
            var  articles = await _unitOfWork.Articles.GetAllAsync();
            if (articles.Count > -1)
            {
                foreach(var article in articles)
                {
                    article.Category = await _unitOfWork.Categories.GetAsync(c => c.id == article.CategoryId);
                }
                return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    ArticleListDto_ = articles,
                    ResultStatus = ResultStatus.Success
                }); }

            else
                return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(false));

        }
            
        

        public async Task<IDataResult<ArticleListDto>> GetAllByCategoryAsync(int categoryID)
        {
            bool categoryExsit = await _unitOfWork.Categories.AnyAsync(c => c.id == categoryID);
            if (categoryExsit)
            {
                var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryID && a.isActive && !a.isDeleted, a => a.user);
                if (articles.Count > -1)
                {
                    return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        ArticleListDto_ = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }
                else
                    return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(true));


            }
            return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Category.NotFound(false));

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAsync()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.isDeleted == true, a => a.Category, a => a.user);
            if (articles != null)
            {
                return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    ArticleListDto_ = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(true));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActiveAsync()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.isActive == true && a.isDeleted == false, a => a.user, a => a.Category);
            if (articles != null)
            {
                return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    ArticleListDto_ = articles,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(true));
        }

        public async Task<IResult> HardDeleteAsync(int articleId)
        {
            var articleExsit = await _unitOfWork.Articles.AnyAsync(a => a.id == articleId);
            if (articleExsit)
            {
                var article = await _unitOfWork.Articles.GetAsync(a => a.id == articleId);
                await _unitOfWork.Articles.DeleteAsync(article).ContinueWith(t => _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.HardDelete(article.title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
        }

        public async Task<IResult> UpdateAsync(ArticleUpdatDto articleUpdatto, string modifiedByName)
        {
            var article = _mapper.Map<Article>(articleUpdatto);

            article.modifiedByName = modifiedByName;
            await _unitOfWork.Articles.UpdateAsync(article).ContinueWith(t => _unitOfWork.saveAsync());

            return new Result(ResultStatus.Success, Messages.Article.Update(article.title));




        }




    }
}
