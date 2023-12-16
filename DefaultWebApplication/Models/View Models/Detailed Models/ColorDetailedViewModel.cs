using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.View_Models.Detailed_Models
{
    public class ColorDetailedViewModel : DetailedViewModel
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorTagName { get; set; }
        public string ColorRgbCode { get; set; }
        public List<ItemSummaryViewModel> ItemModels { get; set; }
    }
}
