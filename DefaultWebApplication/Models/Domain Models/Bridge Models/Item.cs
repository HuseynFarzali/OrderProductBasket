using DefaultWebApplication.Models.Domain_Models.Main_Models;

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
        public Product Product { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}
