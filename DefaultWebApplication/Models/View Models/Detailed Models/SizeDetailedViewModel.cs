using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class SizeDetailedViewModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string SizeTagName { get; set; }
        public IList<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
