using DefaultWebApplication.Models.View_Models.Detailed_Models;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class ColorSummaryViewModel
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorTagName { get; set; }
        public string ColorRgbCode { get; set; }
        public bool ColorDeleted { get; set; }
        public ColorDetailedViewModel ColorDetailedViewModel { get; set; }
    }
}

