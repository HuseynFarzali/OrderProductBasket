using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using DefaultWebApplication.Temporaries;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.Domain_Models.Main_Models
{
    public class Order : DomainModel
    {
        #region Internal Fields
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        #endregion

        #region External Dependencies
        public List<BasketItem>  BasketItemList { get; set; }
        #endregion
    }
}
