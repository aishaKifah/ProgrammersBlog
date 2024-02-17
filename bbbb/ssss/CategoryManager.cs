using programmersBlog.Data.Abstract;
using programmersBlog.Entities.Concrete;
using programmersBlog.Entities.Dtos;
using programmersBlog.Services.Abstract;
using programmersBlog.Shared.Utilities.Results.Abstract;
using programmersBlog.Shared.Utilities.Results.Concrete;
using programmersBlog.Shared.Utilities.Results.ComplexType;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using programmersBlog.Services.Utilities;

namespace programmersBlog.Services
{
    class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;


        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {

            var category = await _unitOfwork.categories.GetAsync(c => c.id == categoryId, c => c.Articles);

            if (category != null)
            {
                return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    CategoryDto_ = category
                });
            }
            else
                return new ResultData<CategoryDto>(ResultStatus.Error, new CategoryDto { 
                    CategoryDto_=null,
                    ResultStatus=ResultStatus.Error,
                    Massege= Messages.Category.NotFound(isPlural: false)
                }, Messages.Category.NotFound(isPlural: false));
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfwork.categories.GetAllAsync(null,c => c.Articles);
            Console.WriteLine(categories.Count);


            if (categories.Count > -1)
            {
                return new ResultData<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    CategoryListDto_ = categories,
                    ResultStatus = ResultStatus.Success,
                  
                });

            }
            else
                return new ResultData<CategoryListDto>(ResultStatus.Error, new CategoryListDto { CategoryListDto_=null, 
                    ResultStatus=ResultStatus.Error,Massege= Messages.Category.NotFound(isPlural: true)
                }, Messages.Category.NotFound(isPlural: true));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNoneDeleted()
        {
            var categories = await _unitOfwork.categories.GetAllAsync(c => !c.isDeleted, c => c.Articles);

            if (categories.Count > -1)
            {
                return new ResultData<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    CategoryListDto_ = categories,
                    ResultStatus = ResultStatus.Success,
                    Massege = "categories are sent sucssefully !"
                });

            }
            else
                return new ResultData<CategoryListDto>(ResultStatus.Error, new CategoryListDto
                {
                    CategoryListDto_ = null,
                    ResultStatus = ResultStatus.Error,
                    Massege = Messages.Category.NotFound(isPlural: true)
                }, Messages.Category.NotFound(isPlural: true));
        }

        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddto, string createdByname)
        {
            var addedCategory=await _unitOfwork.categories.AddAsync(new Category
            {
                Name = categoryAddto.Name,
                Description = categoryAddto.Description,
                note = categoryAddto.Note,
                isActive = categoryAddto.IsActive,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                createdByname = createdByname,
                modifiedByName = createdByname,
                isDeleted = false

            });
            await _unitOfwork.saveAsync();
            return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                CategoryDto_ = addedCategory,
                ResultStatus = ResultStatus.Success,
                Massege = Messages.Category.Add(addedCategory.Name)
            }, Messages.Category.Add(addedCategory.Name)) ;


        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdatDto categoryUpdatto, string modifiedByName)
        {
            var category = await _unitOfwork.categories.GetAsync(c => c.id == categoryUpdatto.Id);
          
                category.Name = categoryUpdatto.Name;
                category.Description = categoryUpdatto.Description;
                category.note = categoryUpdatto.Note;
                category.isActive = categoryUpdatto.IsActive;
                category.modifiedDate = DateTime.Now;
                category.modifiedByName = modifiedByName;
                category.isDeleted = categoryUpdatto.isDeleted;
                await _unitOfwork.categories.UpdateAsync(category);
                await _unitOfwork.saveAsync();
            return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                CategoryDto_ = category,
                ResultStatus = ResultStatus.Success,
                Massege = Messages.Category.Update(category.Name)
            }, Messages.Category.Update(categoryUpdatto.Name)) ;
            
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfwork.categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.isDeleted = true;
                category.modifiedByName = modifiedByName;
                category.modifiedDate = DateTime.Now;
                var deletedCategory=await _unitOfwork.categories.UpdateAsync(category);
                await _unitOfwork.saveAsync();
                return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    CategoryDto_ = deletedCategory,
                    Massege= Messages.Category.Delete(category.Name),
                    ResultStatus=ResultStatus.Success

                }, Messages.Category.Delete(category.Name)) ;

            }
            return new ResultData<CategoryDto>(ResultStatus.Error,new CategoryDto {
                CategoryDto_=null,
                Massege = Messages.Category.NotFound(isPlural: false),
                ResultStatus = ResultStatus.Error
            } ,Messages.Category.NotFound(isPlural:false));// Messages metdodunu kullanmadim 

        }



        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfwork.categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.isDeleted = true;

                await _unitOfwork.categories.DeleteAsync(category);
                await _unitOfwork.saveAsync();
                return new Result(ResultStatus.Success, Messages.Category.HardDelete(category.Name));

            }
            return new Result(ResultStatus.Error, Messages.Category.NotFound(false));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActive()
        {
            var categories = await _unitOfwork.categories.GetAllAsync(c => !c.isDeleted && c.isActive, c => c.Articles);
            if (categories.Count > -1)
            {
                return new ResultData<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    CategoryListDto_ = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            else
                return new ResultData<CategoryListDto>(ResultStatus.Error, null, Messages.Category.NotFound(isPlural: true));

        }

        public async Task<IDataResult<CategoryUpdatDto>> GetUpdateDto(int categoryId) 
        {
            var result = await _unitOfwork.categories.AnyAsync(c=>c.id==categoryId);
            if (result)
            {
                var category = await _unitOfwork.categories.GetAsync(c => c.id == categoryId);
                var categoryUpdatDto = _mapper.Map<CategoryUpdatDto>(category);
                return new ResultData<CategoryUpdatDto>(ResultStatus.Success, categoryUpdatDto);

            }
            return new ResultData<CategoryUpdatDto>(ResultStatus.Error, null, Messages.Category.NotFound(isPlural: false));


        }
    }
}
