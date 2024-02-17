using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Helpers.Abstarct
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages");
        IDataResult<ImageDeleteDto> DeleteImage(string pictureName);

    }
}
