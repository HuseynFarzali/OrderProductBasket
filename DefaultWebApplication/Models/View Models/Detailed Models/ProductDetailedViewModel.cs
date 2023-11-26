using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class ProductDetailedViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductTagName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductRating { get; set; }
        public IList<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
