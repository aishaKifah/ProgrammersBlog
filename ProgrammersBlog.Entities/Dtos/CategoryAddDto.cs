using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {

        // veri transfer objesi kullaniciya objenin butun  ozelliklerini gostermemesi icin kullaniyoruz 
        // Data annotation to show error msgs in front end
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(100, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(3, ErrorMessage = "{0} cann't be less than {1}")]

        public string Name { get; set; }
        [DisplayName("Category Descreption")]
        [MaxLength(500, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(10, ErrorMessage = "{0} cann't be less than {1}")]
        public string Description { get; set; }

        [DisplayName("Category note")]
        [MaxLength(200, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(10, ErrorMessage = "{0} cann't be less than {1}")]
        public string Note { get; set; }

        [DisplayName("Is Active?")]
        [Required(ErrorMessage = "Please addd {0} ")]

        public bool IsActive { get; set; }


    }
}
