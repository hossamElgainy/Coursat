using System.ComponentModel.DataAnnotations;

namespace Coursat.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100,MinimumLength =2)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 2)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
        public string LoginInValid { get; set;}
        public string ReturnUrl { get; set;}
    }
}
