using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coursat.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 2)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 2)]
        public string ConfirmPassword { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        [StringLength(200, MinimumLength = 2)]
        public string LastName { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Address1 { get; set; }


        [StringLength(200, MinimumLength = 2)]
        public string? Address2 { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool AcceptUserAgreement { get; set; }

        public string RegistrationInValid { get; set; }
        

    }
}
