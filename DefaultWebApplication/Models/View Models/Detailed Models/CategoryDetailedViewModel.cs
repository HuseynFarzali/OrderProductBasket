using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class CategoryDetailedViewModel : DetailedViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTagName { get; set; }
        public List<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
