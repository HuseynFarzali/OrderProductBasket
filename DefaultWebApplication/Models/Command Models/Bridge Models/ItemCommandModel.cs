using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;

namespace DefaultWebApplication.Models.Command_Models.Bridge_Models
{
    public class ItemCommandModel
    {
        [Display(Name = "Item Name (optional)")]
        [MinLength(3), MaxLength(50)]
        public string? ItemName { get; set; }

        [Display(Name = "Select a product:")]
        [Required]
        public Product ItemProduct { get; set; }

        [Display(Name = "Select a size:")]
        [Required]
        public Size SizeName { get; set; }

        [Display(Name = "Select a color:")]
        [Required]
        public Color ColorName { get; set; }

        [Display(Name = "Select a category:")]
        [Required]
        public Category CategoryName { get; set; }
    }
}
