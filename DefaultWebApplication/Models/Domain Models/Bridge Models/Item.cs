namespace DefaultWebApplication.Models.Domain_Models.Bridge_Models
{
    public class Item
    {
        #region Internal Fields
        public int ItemId { get; set; }
        public string Name { get; set; }
        #endregion

        #region External Dependencies
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int CategoryId { get; set; }
        #endregion
    }
}
