using System.ComponentModel.DataAnnotations;

namespace DefaultWebApplication.Models.Command_Models.Main_Models
{
    public class ProductCommandModel
    {
        [Display(Name = "Name of the product")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string ProductName { get; set; }

        [Display(Name = "Tag name of the product")]
        [StringLength(3, MinimumLength = 3)]
        public string? ProductTagName { get; set; }

        [Display(Name = "Price of the product")]
        [Required]
        [Range(0.01, 120000)]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Rating of the product")]
        [Required]
        [Range(1, 5)]
        public int ProductRating { get; set; }
    }
}
