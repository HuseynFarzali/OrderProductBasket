using DefaultWebApplication.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DefaultWebApplication.Models.Command_Models.Main_Models
{
    public class ColorCommandModel
    {
        [Display(Name = "Name of the color")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string ColorName { get; set; }

        [Display(Name = "Tag name of the color")]
        [StringLength(3, MinimumLength = 3)]
        public string? ColorTagName { get; set; }

        [Required]
        [RGBCode(ErrorMessage = "{0} is not in valid format of {1}")]
        public string ColorRgbCode { get; set; }
    }
}
