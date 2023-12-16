using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Pages.Size;

namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class SizeSummaryViewModel
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public string SizeTagName { get; set; }
        public bool SizeDeleted { get; set; }
        public SizeDetailedViewModel SizeDetailedViewModel { get; set; }
    }
}
