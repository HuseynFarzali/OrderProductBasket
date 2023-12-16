using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using System.Collections;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.Domain_Models.Main_Models
{
    public class Product : DomainModel
    {
        #region internal Fields
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string TagName { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        #endregion

        #region External Dependencies
        public List<Item> ItemList { get; set; }
        #endregion
    }
}
