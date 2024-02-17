using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryUpdateAjaxViewModel
    {
        public CategoryUpdatDto categoryUpdateDto { get; set; }
        public CategoryDto categoryDto { get; set; }
        public string categoryUpdatePartial { get; set; }


    }
}
