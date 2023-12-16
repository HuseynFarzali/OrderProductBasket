using DefaultWebApplication.Models.View_Models.Detailed_Models;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class CategorySummaryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTagName { get; set; }
        public bool CategoryDeleted { get; set; }
        public CategoryDetailedViewModel CategoryDetailedViewModel { get; set; }
    }
}