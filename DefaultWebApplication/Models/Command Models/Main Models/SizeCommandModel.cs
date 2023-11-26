using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DefaultWebApplication.Models.Command_Models.Main_Models
{
    public class SizeCommandModel
    {
        [Display(Name = "Name of the size")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string SizeName { get; set; }

        [Display(Name = "Tag name of the size")]
        [StringLength(3, MinimumLength = 3)]
        public string? SizeTagName { get; set; }
    }
}
