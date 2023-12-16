using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Extensions;
using DefaultWebApplication.Models.Command_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class ItemRepository : IRepository<Item, ItemCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<Item> CreateEntity(ItemCommandModel command)
        {
            var item = new Item
            {
                Name = command.ItemName ?? GenerateItemName(command),

                ProductId = command.ItemProduct.ProductId,
                Product = command.ItemProduct,

                SizeId = command.ItemSize.SizeId,
                Size = command.ItemSize,

                ColorId = command.ItemColor.ColorId,
                Color = command.ItemColor,

                CategoryId = command.ItemCategory.CategoryId,
                Category = command.ItemCategory
            };

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteEntityCollection(Func<Item, bool> criteria)
        {
            var matchingItems = await _context.Items.ToListAsync();
            matchingItems = matchingItems.Where(criteria).ToList();

            foreach (var matchingItem in matchingItems)
            {
                matchingItem.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetEntityCollection(Func<Item, bool> criteria, bool includeItemList = false)
        {
            var matchingItems = await _context.Items.ToListAsync();
            matchingItems = matchingItems.Where(criteria).ToList();
            return matchingItems;
        }

        public async Task<Item> UpdateEntity(Func<Item, bool> criteriaUnique, ItemCommandModel command)
        {
            var matchingItems = await _context.Items.ToListAsync();
            matchingItems = matchingItems.Where(criteriaUnique).ToList();

            if (matchingItems.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingItems.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var item = matchingItems.First();

            item.Name = command.ItemName ?? GenerateItemName(command);

            item.ProductId = command.ItemProduct.ProductId;
            item.Product = command.ItemProduct;

            item.SizeId = command.ItemSize.SizeId;
            item.Size = command.ItemSize;

            item.ColorId = command.ItemColor.ColorId;
            item.Color = command.ItemColor;

            item.CategoryId = command.ItemCategory.CategoryId;
            item.Category = command.ItemCategory;

            await _context.SaveChangesAsync();
            return item;
        }
        #endregion

        #region Specific Methods
        public async Task<Item> CreateItem(ItemCommandModel command)
            => await CreateEntity(command);

        public async Task DeleteItemById(int itemId)
        {
            await DeleteEntityCollection(item => item.ItemId == itemId);
        }

        public async Task<Item> GetItemById(int itemId)
        {
            var enumerableItemList = await GetEntityCollection(item => item.ItemId == itemId);
            return enumerableItemList.First();
        }

        public async Task<Item> UpdateItemById(int itemId, ItemCommandModel command)
            => await UpdateEntity(item => item.ItemId == itemId, command);
        #endregion

        #region Helper Methods
        private string GenerateItemName(ItemCommandModel command)
        {
            return command.ItemProduct.Name[0].ToString()
                + command.ItemSize.Name[0]
                + command.ItemColor.Name[0];
        }
        #endregion
    }
}
