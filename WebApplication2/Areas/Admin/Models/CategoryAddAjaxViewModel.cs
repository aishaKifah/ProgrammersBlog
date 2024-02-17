using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class CategoryAddAjaxViewModel
    {
        public CategoryAddDto categoryAddDto { get; set; }
        public CategoryDto categoryDto { get; set; }
        public string categoryAddPartial { get; set; }


    }
}
