using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserUpdateDto
    {
        // veri transfer objesi kullaniciya objenin butun  ozelliklerini gostermemesi icin kullaniyoruz 
        // Data annotation to show error msgs in front end
        [Required]
        public int Id { get; set; }

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

        [DisplayName("Image")]

        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }

        public string Picture { get; set; }



    }
}
