using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Extensions;
using DefaultWebApplication.Models.Command_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.TypeHandlers.GeometricHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class BasketItemRepository : IRepository<BasketItem, BasketItemCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public BasketItemRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<BasketItem> CreateEntity(BasketItemCommandModel command)
        {
            var basketItem = new BasketItem
            {
                Name = command.BasketItemName ?? GenerateBasketItemName(command),
                Ordered = false,
                Quantity = command.BasketItemQuantity,

                UserId = command.BasketItemUser.UserId,
                User = command.BasketItemUser,

                ItemId = command.BasketItemItem.ItemId,
                Item = command.BasketItemItem,

                OrderId = command.BasketItemOrder.OrderId,
                Order = command.BasketItemOrder
            };

            await _context.BasketItems.AddAsync(basketItem);
            await _context.SaveChangesAsync();

            return basketItem;
        }

        public async Task DeleteEntityCollection(Func<BasketItem, bool> criteria)
        {
            var matchingBasketItems = await _context.BasketItems.ToListAsync();
            matchingBasketItems = matchingBasketItems.Where(criteria).ToList();

            foreach (var matchingBasketItem in matchingBasketItems)
            {
                matchingBasketItem.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BasketItem>> GetEntityCollection(
            Func<BasketItem, bool> criteria, bool includeItemList = false)
        {
            var matchingBasketItems = await _context.BasketItems.ToListAsync();
            matchingBasketItems = matchingBasketItems.Where(criteria).ToList();
            return matchingBasketItems;
        }

        public async Task<BasketItem> UpdateEntity(Func<BasketItem, bool> criteriaUnique, BasketItemCommandModel command)
        {
            var matchingBasketItems = await _context.BasketItems.ToListAsync();
            matchingBasketItems = matchingBasketItems.Where(criteriaUnique).ToList();

            if(matchingBasketItems.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if(!matchingBasketItems.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var basketItem = matchingBasketItems.First();

            basketItem.Name = command.BasketItemName;
            basketItem.Quantity = command.BasketItemQuantity;

            basketItem.UserId = command.BasketItemUser.UserId;
            basketItem.User = command.BasketItemUser;

            basketItem.ItemId = command.BasketItemItem.ItemId;
            basketItem.Item = command.BasketItemItem;

            basketItem.OrderId = command.BasketItemOrder.OrderId;
            basketItem.Order = command.BasketItemOrder;

            await _context.SaveChangesAsync();
            return basketItem;
        }
        #endregion

        #region Specific Methods
        public async Task<BasketItem> CreateBasketItem(BasketItemCommandModel command)
            => await CreateEntity(command);

        public async Task DeleteBasketItemById(int basketItemId)
        {
            await DeleteEntityCollection(basketItem => basketItem.BasketItemId == basketItemId);
        }

        public async Task<BasketItem> GetBasketItemById(int basketItemId)
        {
            var enumerableBasketItemList = await GetEntityCollection(basketItem => basketItem.BasketItemId == basketItemId);
            return enumerableBasketItemList.First();
        }

        public async Task<BasketItem> UpdateBasketItemById(int basketItemId, BasketItemCommandModel command)
            => await UpdateEntity(basketItem => basketItem.BasketItemId == basketItemId, command);

        public async Task<BasketItem> IncreaseBasketItemQuantity(int basketItemId, int increment = 1)
        {
            var basketItem = await GetBasketItemById(basketItemId);
            basketItem.Quantity += increment;

            await _context.SaveChangesAsync();
            return basketItem;
        }
        #endregion

        #region Helper Methods
        private string GenerateBasketItemName(BasketItemCommandModel command)
        {
            return command.BasketItemUser.Name[0..2] + command.BasketItemItem.Name[0];
        }
        #endregion
    }
}
