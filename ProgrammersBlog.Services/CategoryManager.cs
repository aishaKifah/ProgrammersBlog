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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;


        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;

        }
     
        public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
        {

            var category = await _unitOfwork.Categories.GetAsync(c => c.id == categoryId, c => c.Articles);


            if (category != null)
            {
                return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    CategoryDto_ = category
                });
            }
            else
                return new ResultData<CategoryDto>(ResultStatus.Error, new CategoryDto
                {
                    CategoryDto_ = null,
                    ResultStatus = ResultStatus.Error,
                    Massege = Messages.Category.NotFound(isPlural: false)
                }, Messages.Category.NotFound(isPlural: false));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await _unitOfwork.Categories.GetAllAsync(null);
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
                return new ResultData<CategoryListDto>(ResultStatus.Error, new CategoryListDto
                {
                    CategoryListDto_ = null,
                    ResultStatus = ResultStatus.Error,
                    Massege = Messages.Category.NotFound(isPlural: true)
                }, Messages.Category.NotFound(isPlural: true));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAsync()
        {
            var categories = await _unitOfwork.Categories.GetAllAsync(c => !c.isDeleted);

            if (categories.Count > -1)
            {
                return new ResultData<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    CategoryListDto_ = categories,
                    ResultStatus = ResultStatus.Success,
                    Massege = "Categories are sent sucssefully !"
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
        /// <summary>
        ///Adds a new Category to dataBase using uniitofwork 
        /// </summary>
        /// <param name="categoryAddto"> CategoryAddDto type to be added </param>
        /// <param name="createdByname"> string represntaion of the Catgory creator </param>
        /// <returns>Using Async operation returns DataResult as Task </returns>
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddto, string createdByname)
        {
            var addedCategory = await _unitOfwork.Categories.AddAsync(new Category
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
            }, Messages.Category.Add(addedCategory.Name));


        }

        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdatDto categoryUpdatto, string modifiedByName)
        {
            var category = await _unitOfwork.Categories.GetAsync(c => c.id == categoryUpdatto.Id);

            category.Name = categoryUpdatto.Name;
            category.Description = categoryUpdatto.Description;
            category.note = categoryUpdatto.Note;
            category.isActive = categoryUpdatto.IsActive;
            category.modifiedDate = DateTime.Now;
            category.modifiedByName = modifiedByName;
            category.isDeleted = categoryUpdatto.isDeleted;
            await _unitOfwork.Categories.UpdateAsync(category);
            await _unitOfwork.saveAsync();
            return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
            {
                CategoryDto_ = category,
                ResultStatus = ResultStatus.Success,
                Massege = Messages.Category.Update(category.Name)
            }, Messages.Category.Update(categoryUpdatto.Name));

        }

        public async Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await _unitOfwork.Categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.isDeleted = true;
                category.modifiedByName = modifiedByName;
                category.modifiedDate = DateTime.Now;
                var deletedCategory = await _unitOfwork.Categories.UpdateAsync(category);
                await _unitOfwork.saveAsync();
                return new ResultData<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    CategoryDto_ = deletedCategory,
                    Massege = Messages.Category.Delete(category.Name),
                    ResultStatus = ResultStatus.Success

                }, Messages.Category.Delete(category.Name));

            }
            return new ResultData<CategoryDto>(ResultStatus.Error, new CategoryDto
            {
                CategoryDto_ = null,
                Massege = Messages.Category.NotFound(isPlural: false),
                ResultStatus = ResultStatus.Error
            }, Messages.Category.NotFound(isPlural: false));// Messages metdodunu kullanmadim 

        }



        public async Task<IResult> HardDeleteAsync(int categoryId)
        {
            var category = await _unitOfwork.Categories.GetAsync(c => c.id == categoryId);
            if (category != null)
            {
                category.isDeleted = true;

                await _unitOfwork.Categories.DeleteAsync(category);
                await _unitOfwork.saveAsync();
                return new Result(ResultStatus.Success, Messages.Category.HardDelete(category.Name));

            }
            return new Result(ResultStatus.Error, Messages.Category.NotFound(false));
        }

        public async Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActiveAsync()
        {
            var categories = await _unitOfwork.Categories.GetAllAsync(c => !c.isDeleted && c.isActive, c => c.Articles);
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
        /// <summary>
        /// Returns the CategoryDto represntation of the input categoryId 
        /// </summary>
        /// <param name="categoryId"> categoryId >0</param>
        /// <returns>Using async operation returns DataResult type as a Task  </returns>
        public async Task<IDataResult<CategoryUpdatDto>> GetCategoryUpdateDtoAsync(int categoryId)
        {
            var result = await _unitOfwork.Categories.AnyAsync(c => c.id == categoryId);
            if (result)
            {
                var category = await _unitOfwork.Categories.GetAsync(c => c.id == categoryId);
                var categoryUpdatDto = _mapper.Map<CategoryUpdatDto>(category);
                return new ResultData<CategoryUpdatDto>(ResultStatus.Success, categoryUpdatDto);

            }
            return new ResultData<CategoryUpdatDto>(ResultStatus.Error, null, Messages.Category.NotFound(isPlural: false));


        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var categoriesCount = await _unitOfwork.Categories.CountAsync();
            if (categoriesCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }

        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var categoriesCount = await _unitOfwork.Categories.CountAsync(c=>!c.isDeleted) ;
            if (categoriesCount > -1)
            {
                return new ResultData<int>(ResultStatus.Success, categoriesCount);
            }
            else
            {
                return new ResultData<int>(ResultStatus.Error, -1, "unknown Error ! ");
            }
        }
    }
}
