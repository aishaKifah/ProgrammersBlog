using ProgrammersBlog.Entities.Concrete;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Tilte")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(100, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        public String tilte { get; set; }

        [DisplayName("Content")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MinLength(30, ErrorMessage = "{0} cann't be less than {1}")]
        public String content { get; set; }

        [DisplayName("Image URL")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(250, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        public String thumbnail { get; set; }//resmin yolu

        [DisplayName("Date Time")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }


        [DisplayName("SEO Description")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(150, ErrorMessage = "{0} cann't be more than {1}")]
        public String seoDescreption { get; set; }

        [DisplayName("SEO Tags")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(70, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        public String seoTags { get; set; }

        [DisplayName("SEO Auother")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(50, ErrorMessage = "{0} cann't be more than {1}")]
        public String seoAouther { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Please addd {0} ")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Is it Active?")]
        [Required(ErrorMessage = "Please addd {0} ")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }



    }
}
