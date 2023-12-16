using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Models.View_Models.Summary_Models;
using System.Collections.Generic;

namespace DefaultWebApplication.Extensions
{
    public static class ItemConverter
    {
        public static ItemSummaryViewModel ConvertToSummaryModel(this Item item)
        {
            return new ItemSummaryViewModel
            {
                ItemDeleted = item.Deleted,
                ItemName = item.Name,
                ItemDetailedViewModel = new ItemDetailedViewModel
                {
                    ItemId = item.ItemId,
                    ItemName = item.Name,
                },
            };
        }

        public static List<ItemSummaryViewModel> ConvertToSummaryModels(this List<Item> items)
        {
            var itemsModel = new List<ItemSummaryViewModel>();
            foreach (var item in items)
            {
                itemsModel.Add(ConvertToSummaryModel(item));
            }
            
            return itemsModel;
        }

        public static List<ItemSummaryViewModel> ConvertToSummaryModels(this List<BasketItem> basketItems)
        {
            var itemsModel = new List<ItemSummaryViewModel>();
            foreach (var basketItem in basketItems)
            {
                itemsModel.Add(ConvertToSummaryModel(basketItem.Item));
            }

            return itemsModel;
        }
    }
}
