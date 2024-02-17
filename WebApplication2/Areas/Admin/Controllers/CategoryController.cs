using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin, editor")]

    public class CategoryController : Controller
    {
        //categorys calling 
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllByNoneDeletedAsync();

            return View(result.data);


        }
        [HttpGet]
        public IActionResult Add()
        {


            return PartialView("_CategoryAddPartial");


        }
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {

            var result = await _categoryService.GetCategoryUpdateDtoAsync(categoryId);
            if (result.resultStatus == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.data);
            }
            return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                var result = await _categoryService.AddAsync(categoryAddDto, "Aycha Yahia");
                if (result.resultStatus == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
                    {
                        categoryDto = result.data,
                        categoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {

                categoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)
            });
            return Json(categoryAddAjaxErrorModel);


        }
        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllByNoneDeletedAsync();
            var categories = JsonSerializer.Serialize(result.data, new JsonSerializerOptions
            {// birbirine referens eden veriler oldugu icin ReferenceHandler kullaniyoruz yoksa sikinti cikabilir
                ReferenceHandler = ReferenceHandler.Preserve


            });
            return Json(categories);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int categoryToDelete)
        {
            var result = await _categoryService.DeleteAsync(categoryToDelete, "Aycha yahia");
            var deletedCategory = JsonSerializer.Serialize(result.data);
            return Json(deletedCategory);


        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdatDto categoryUpdatDto)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                var result = await _categoryService.UpdateAsync(categoryUpdatDto, "Aycha Yahia");
                if (result.resultStatus == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
                    {
                        categoryDto = result.data,
                        categoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdatDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {

                categoryAddPartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdatDto)
            });
            return Json(categoryUpdateAjaxErrorModel);


        }

        /* [HttpPost]
         public async Task<JsonResult> UpdateAsync(int categoryToUpdatId, CategoryAddDto categoryToUpdat)
         {
             var result = await _categoryService.GetCategoryUpdateDtoAsync(categoryToUpdatId);
             if (result.resultStatus == ResultStatus.Success) { 
             result.data.CategoryDto_.Name = categoryToUpdat.Name;
             result.data.CategoryDto_.note = categoryToUpdat.Note;




         }*/
    }


}
