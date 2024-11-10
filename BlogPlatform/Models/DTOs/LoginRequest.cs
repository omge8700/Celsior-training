using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email required")]
        [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Enter Valid Email")]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password required")]
        [MinLength(6, ErrorMessage = "Length should be more than or equal to 6")]
        public string Password { get; set; } = string.Empty;

    }
}
