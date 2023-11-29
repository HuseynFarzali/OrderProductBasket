using DefaultWebApplication.Models.Domain_Models.Main_Models;

namespace DefaultWebApplication.Models.Domain_Models.Bridge_Models
{
    public class BasketItem : DomainModel
    {
        #region Internal Fields
        public int BasketItemId { get; set; }
        public string Name { get; set; }
        public bool Ordered { get; set; }
        public int Quantity { get; set; } = 0;
        #endregion

        #region External Dependencies
        public int UserId { get; set; }
        public User User { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int? OrderId { get; set; } 
        public Order? Order { get; set; }
        #endregion
    }
}
