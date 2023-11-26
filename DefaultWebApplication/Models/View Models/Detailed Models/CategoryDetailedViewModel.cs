using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class CategoryDetailedViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTagName { get; set; }
        public IList<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
