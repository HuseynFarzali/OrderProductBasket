﻿namespace DefaultWebApplication.Models.Domain_Models.Bridge_Models
{
    public class BasketItem
    {
        #region Internal Fields
        public int BasketItemId { get; set; }
        public string Name { get; set; }
        public bool Ordered { get; set; }
        #endregion

        #region External Dependencies
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int? OrderId { get; set; }
        #endregion
    }
}