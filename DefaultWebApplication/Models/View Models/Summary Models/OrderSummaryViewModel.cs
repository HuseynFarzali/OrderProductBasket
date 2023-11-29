using DefaultWebApplication.Temporaries;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class OrderSummaryViewModel
    {
        public string OrderNumber { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal OrderTotalPrice { get; set; }
    }
}
