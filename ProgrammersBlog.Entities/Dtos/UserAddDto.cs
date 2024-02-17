using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserAddDto
    {
        // veri transfer objesi kullaniciya objenin butun  ozelliklerini gostermemesi icin kullaniyoruz 
        // Data annotation to show error msgs in front end

        [DisplayName("Username")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(50, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(3, ErrorMessage = "{0} cann't be less than {1}")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(100, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(10, ErrorMessage = "{0} cann't be less than {1}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [DisplayName("Phone Number ")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(13, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(13, ErrorMessage = "{0} cann't be less than {1}")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(30, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Image")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; }



    }
}
