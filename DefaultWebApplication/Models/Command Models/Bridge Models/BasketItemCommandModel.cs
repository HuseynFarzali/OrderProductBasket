using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using System.ComponentModel.DataAnnotations;

namespace DefaultWebApplication.Models.Command_Models.Bridge_Models
{
    public class BasketItemCommandModel
    {
        [Display(Name = "Item name from the basket")]
        [MinLength(3), MaxLength(50)]
        public string BasketItemName { get; set; }

        [Display(Name = "Quantity of the selected item to add")]
        [Required]
        public int BasketItemQuantity { get; set; }

        [Required]
        public User BasketItemUser { get; set; }

        [Required]
        public Item BasketItemItem { get; set; }

        public Order? BasketItemOrder { get; set; }
    }
}
