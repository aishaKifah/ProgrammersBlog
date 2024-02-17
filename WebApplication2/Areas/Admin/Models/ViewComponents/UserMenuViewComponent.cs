
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models.ViewComponents
{
    public class UserMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public ViewViewComponentResult Invoke()
        {
            // direkt user'i gonderebilirdik ama model kullanmak daha saglam bir yontem. ilerde view'ye user'den baska bilgiler gondermek gerekebilir
            var user = _userManager.GetUserAsync(HttpContext.User).Result;//HttpContext.User hangi user giris yapmis diye bilgi veriyor 
            return View(new UserViewModel
            {
                User = user


            });
        }
    }
}
