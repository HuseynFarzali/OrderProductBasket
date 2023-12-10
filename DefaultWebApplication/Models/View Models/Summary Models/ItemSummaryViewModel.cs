namespace DefaultWebApplication.Models.View_Models.Summary_Models
{
    public class ItemSummaryViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ProductName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string CategoryName { get; set; }
        public bool ItemDeleted { get; set; }
    }
}
