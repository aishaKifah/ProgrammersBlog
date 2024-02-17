using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Mvc.Areas.Admin.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Results.ComplexType;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProgrammersBlog.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin, editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        private readonly UserManager<User> _userManager;

        public HomeController(ICategoryService categoryService, ICommentService commentService, IArticleService articleService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _commentService = commentService;
            _articleService = articleService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesCount = await _categoryService.CountByNonDeletedAsync();
            var commentsCount = await _commentService.CountByNoneDeletedAsync();
            var articlesCount = await _articleService.CountByNoneDeletedAsync();
            var usersCount = await _userManager.Users.CountAsync();
            var articlesResult = await _articleService.GetAllAsync();

            if (categoriesCount.resultStatus == ResultStatus.Success && commentsCount.resultStatus == ResultStatus.Success && articlesCount.resultStatus == ResultStatus.Success && usersCount > -1 && articlesResult.resultStatus == ResultStatus.Success)
            {
                var dataDashboardModel = new DashboardViewModel
                {
                    CategoriesCount = categoriesCount.data,
                    ArticlesCount = articlesCount.data,
                    CommentsCount = commentsCount.data,
                    UsersCount = usersCount,
                    Articles = articlesResult.data
                };
              /*  var settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize // or ReferenceLoopHandling.Serialize
                };

                // Serialize the model to JSON with reference handling settings
                var jsonModel = JsonConvert.SerializeObject(dataDashboardModel, Formatting.None, settings);*/

                return View(dataDashboardModel);
            }
            

          
               
            else return NotFound();
        }

    }
}
