using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using System.Collections;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.Domain_Models.Main_Models
{
    public class Size : DomainModel
    {
        #region Internal Fields
        public int SizeId { get; set; }
        public string Name { get; set; }
        public string TagName { get; set; }
        #endregion

        #region External Dependencies
        public IList<Item> ItemList { get; set; }
        #endregion
    }
}
