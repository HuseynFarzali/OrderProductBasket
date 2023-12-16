using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Temporaries;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class OrderDetailedViewModel : DetailedViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public List<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
