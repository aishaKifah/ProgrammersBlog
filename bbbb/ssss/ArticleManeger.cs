using AutoMapper;
using Microsoft.EntityFrameworkCore;
using programmersBlog.Data.Abstract;
using programmersBlog.Entities.Concrete;
using programmersBlog.Entities.Dtos;
using programmersBlog.Services.Abstract;
using programmersBlog.Services.Utilities;
using programmersBlog.Shared.Utilities.Results.Abstract;
using programmersBlog.Shared.Utilities.Results.ComplexType;
using programmersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Services
{
    class ArticleManeger : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork ;
        private readonly IMapper mapper;
        public ArticleManeger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(ArticleAddDto articleAddto, string createdByName)
        {
            var articleRepeated = await _unitOfWork.aticles.AnyAsync(c => c.content.Equals(articleAddto.content));
            if (!articleRepeated)
            {
                var article = await _unitOfWork.aticles.AddAsync(
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
                            modifiedByName=createdByName,
                            userID = 1

                        }
                        ).ContinueWith( t=> _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.Add(articleAddto.tilte));


            }
            else
            {
                return new Result(ResultStatus.Error, Messages.Article.AlreadyExsit(articleAddto.tilte));
           }
           
        }

        public async  Task<IResult> Delete(int articleId, string modifiedByName)
        {
            var articleExsit = await _unitOfWork.aticles.AnyAsync(a => a.id == articleId);
            if (articleExsit)
            {
                var article = await _unitOfWork.aticles.GetAsync(a => a.id == articleId);
                article.isDeleted = true;
                article.modifiedByName = modifiedByName;
                article.Date = DateTime.Now;
                await _unitOfWork.aticles.UpdateAsync(article).ContinueWith(t => _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.Delete(article.title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
        }

        public async Task<IDataResult<ArticleDto>> Get(int articleId)
        {
            var article = await _unitOfWork.aticles.GetAsync(a => a.id == articleId, a=>a.user,a=>a.Category);

            if (article != null)
            {
                return new ResultData<ArticleDto>(ResultStatus.Success, new ArticleDto
                {
                    ArticleDto_ = article,
                    ResultStatus = ResultStatus.Success

                });
            }
            return new ResultData<ArticleDto>(ResultStatus.Error , null, Messages.Article.NotFound(false)) ;

        }

        public async Task<IDataResult<ArticleListDto>> GetAllByCategory(int categoryID)
        {
            bool categoryExsit = await _unitOfWork.categories.AnyAsync(c=>c.id==categoryID);
            if (categoryExsit)
            {
                var articles = await _unitOfWork.aticles.GetAllAsync(a => a.CategoryId == categoryID&&a.isActive&&!a.isDeleted, a => a.user);
                if (articles.Count<-1)
                {
                    return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                    {
                        ArticleListDto_ = articles,
                        ResultStatus = ResultStatus.Success
                    });
                }else
                    return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(true));


            }
            return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Category.NotFound(false));
           
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeleted()
        {
            var articles = await _unitOfWork.aticles.GetAllAsync(a => a.isDeleted == true, a => a.Category, a => a.user);
            if (articles != null)
            {
                return new ResultData<ArticleListDto>(ResultStatus.Success, new ArticleListDto
                {
                    ArticleListDto_ = articles,
                    ResultStatus=ResultStatus.Success
                }) ;
            }
            return new ResultData<ArticleListDto>(ResultStatus.Error, null, Messages.Article.NotFound(true));
        }

        public async Task<IDataResult<ArticleListDto>> GetAllByNoneDeletedAndActice()
        {
            var articles = await _unitOfWork.aticles.GetAllAsync(a => a.isActive == true && a.isDeleted == false, a => a.user, a => a.Category);
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

        public async Task<IResult> HardDelete(int articleId)
        {
            var articleExsit = await _unitOfWork.aticles.AnyAsync(a => a.id == articleId);
            if (articleExsit)
            {
                var article = await _unitOfWork.aticles.GetAsync(a => a.id == articleId);
                await _unitOfWork.aticles.DeleteAsync(article).ContinueWith(t => _unitOfWork.saveAsync());
                return new Result(ResultStatus.Success, Messages.Article.HardDelete(article.title));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
        }

        public async Task<IResult> Updat(ArticleUpdatDto articleUpdatto, string modifiedByName)
        {
                var article = mapper.Map<Article>(articleUpdatto);
           
                article.modifiedByName = modifiedByName;
                await _unitOfWork.aticles.UpdateAsync(article).ContinueWith(t => _unitOfWork.saveAsync());

                return new Result(ResultStatus.Success, Messages.Article.Update(article.title));
            

            
            
        }

    

       
    }
}
