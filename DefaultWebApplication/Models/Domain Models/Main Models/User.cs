using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Models.Domain_Models.Main_Models
{
    public class User : DomainModel
    {
        #region Internal Fields
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string TagName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region External Dependencies
        public List<BasketItem> BasketItemList { get; set; }
        #endregion
    }
}
