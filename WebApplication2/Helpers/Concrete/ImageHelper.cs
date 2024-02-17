using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Helpers.Abstarct;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using ProgrammersBlog.Shared.Utilities.Results.Concrete;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;

        }

        public IDataResult<ImageDeleteDto> DeleteImage(string pictureName)
        {

            var fileTodelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileTodelete))
            {
                var fileInfo = new FileInfo(fileTodelete);
                var imageDeletedDto = new ImageDeleteDto
                {
                    FullName = pictureName,

                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileTodelete);
                return new ResultData<ImageDeleteDto>(ResultStatus.Success, imageDeletedDto);
            }
            else
            {
                return new ResultData<ImageDeleteDto>(ResultStatus.Error, null, $"no image found with {pictureName} name  ");
            }
        }

        public async Task<IDataResult<ImageUploadDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages")
        {
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string newfileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newfileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);// user'in ykledigi resmin img folderine aktiralcaktir 

            };
            return new ResultData<ImageUploadDto>(ResultStatus.Success, new ImageUploadDto
            {

                FullName = $"{folderName}/{newfileName}",

                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            }, $"the image of {userName} user has been successfuly uploaded ");


        }
    }
}
