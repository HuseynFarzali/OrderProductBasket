using DefaultWebApplication.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DefaultWebApplication.Models.Command_Models.Main_Models
{
    public class UserCommandModel
    {
        [Display(Name = "Name")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string UserName { get; set; }

        [Display(Name = "Surname")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string UserSurname { get; set; }

        [Display(Name = "Age")]
        [Required]
        [Range(16, 100)]
        public int UserAge { get; set; }

        [Display(Name = "Tag name of the user")]
        [StringLength(3, MinimumLength = 3)]
        public string? UserTagName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name = "Password")]
        [Required]
        [PasswordPropertyText]
        [Password]
        public string UserPassword { get; set; }
    }
}
