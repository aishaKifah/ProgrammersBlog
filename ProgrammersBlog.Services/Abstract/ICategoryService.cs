
using ProgrammersBlog.Entities.Dtos;

using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
   
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        // back end 'te validasiyonu kintrol etmek icin fluent kullandik ama front end icin data annotation kullniyoruz
        /// <summary>
        /// Returns the CategoryDto represntation of the input categoryId 
        /// </summary>
        /// <param name="categoryId"> categoryId >0</param>
        /// <returns>Using async operation returns DataResult type as a Task  </returns>
        Task<IDataResult<CategoryUpdatDto>> GetCategoryUpdateDtoAsync(int categoryId);

        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActiveAsync();
        /// <summary>
        ///Adds a new Category to dataBase using uniitofwork 
        /// </summary>
        /// <param name="categoryAddto"> CategoryAddDto type to be added </param>
        /// <param name="createdByname"> string represntaion of the Catgory creator </param>
        /// <returns>Using Async operation returns DataResult as Task </returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddto, string createdByname);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdatDto categoryUpdateto, String modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);// getall cagrdigimizda delete olanlar gelemeyecek ama aslinda silinmis degiller
        Task<IResult> HardDeleteAsync(int categoryId);// arka planda tamamen silinme islmeidir
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
