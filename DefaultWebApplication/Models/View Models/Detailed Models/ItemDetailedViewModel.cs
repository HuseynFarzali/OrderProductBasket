using DefaultWebApplication.Models.View_Models.Summary_Models;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class ItemDetailedViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public ProductSummaryViewModel ProductModel { get; set; }
        public ColorSummaryViewModel ColorModel { get; set; }
        public CategorySummaryViewModel CategoryModel { get; set; }
        public SizeSummaryViewModel SizeModel { get; set; }
    }
}
