using DefaultWebApplication.Models.View_Models.Detailed_Models;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class ProductSummaryViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductTagName { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductDeleted { get; set; }
        public ProductDetailedViewModel ProductDetailedViewModel { get; set; }
    }
}
