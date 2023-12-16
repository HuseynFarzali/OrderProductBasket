using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class SizeDetailedViewModel : DetailedViewModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string SizeTagName { get; set; }
        public List<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
