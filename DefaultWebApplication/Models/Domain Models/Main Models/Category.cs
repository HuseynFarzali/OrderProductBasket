using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.Domain_Models.Main_Models
{
    public class Category : DomainModel
    {
        #region Internal Fields
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string TagName { get; set; }
        #endregion

        #region External Dependencies
        public List<Item> ItemList { get; set; }
        #endregion
    }
}
