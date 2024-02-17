using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(30, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(30, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        public string NewPassword { get; set; }

        [DisplayName("Confirm New Password")]
        [Required(ErrorMessage = "Please addd {0} ")]
        [MaxLength(30, ErrorMessage = "{0} cann't be more than {1}")]
        [MinLength(5, ErrorMessage = "{0} cann't be less than {1}")]
        [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
