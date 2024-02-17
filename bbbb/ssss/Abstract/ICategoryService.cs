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
    public interface ICategoryService {
        // back end 'te validasiyonu kintrol etmek icin fluent kullandik ama front end icin data annotation kullniyoruz
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryUpdatDto>> GetUpdateDto(int categoryId);

        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeleted();
        Task<IDataResult<CategoryListDto>> GetAllByNoneDeletedAndActive();

        Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddto, string createdByname);
        Task<IDataResult<CategoryDto>> Update(CategoryUpdatDto categoryUpdateto, String modifiedByName);
        Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName);// getall cagrdigimizda delete olanlar gelemeyecek ama aslinda silinmis degiller
        Task<IResult> HardDelete(int categoryId);// arka planda tamamen silinme islmeidir
    }
}
