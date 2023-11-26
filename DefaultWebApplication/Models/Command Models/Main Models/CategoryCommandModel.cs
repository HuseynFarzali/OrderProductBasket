using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DefaultWebApplication.Models.Command_Models.Main_Models
{
    public class CategoryCommandModel
    {
        [Display(Name = "Name of the category")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string CategoryName { get; set; }

        [Display(Name = "Tag name of the category")]
        [StringLength(3, MinimumLength = 3)]
        public string? CategoryTagName { get; set; }
    }
}
