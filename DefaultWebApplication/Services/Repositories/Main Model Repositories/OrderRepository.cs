using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Models.Command_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Bridge_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Bridge_Model_Repositories;
using DefaultWebApplication.Temporaries;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class OrderRepository
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;
        private readonly BasketItemRepository _basketItemRepository;

        public OrderRepository(AppDbContext context, BasketItemRepository basketItemRepository)
        {
            _context = context;
            _basketItemRepository = basketItemRepository;
        }
        #endregion

        #region Main Methods
        public async Task<Order> CreateEntity(IEnumerable<BasketItem> basketItems)
        {
            var newOrder = new Order
            {
                OrderNumber = GenerateUniqueOrderNumber(),
                Status = OrderStatus.Created,
                TotalPrice = CalculateTotalPriceOfBasketItems(basketItems),
            };

            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task DeleteEntityCollection(Func<Order, bool> criteria)
        {
            var matchingOrders = await _context.Orders.Where(o => criteria(o)).ToListAsync();
            foreach (var matchingOrder in matchingOrders)
            {
                matchingOrder.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetEntityCollection(Func<Order, bool> criteria)
        {
            var matchingOrders = await _context.Orders.Where(o => criteria(o)).ToListAsync();

            if (!matchingOrders.Any())
                throw new Exception("Given criteria is not satisfied by any entity in the context.");

            return matchingOrders;
        }

        public async Task<Order> UpdateEntity(Func<Order, bool> criteriaUnique, OrderStatus status)
        {
            var matchingOrders = await _context.Orders.Where(o => criteriaUnique(o)).ToListAsync();

            if (!matchingOrders.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");
            if (matchingOrders.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");

            var order = matchingOrders.First();

            order.Status = status;

            await _context.SaveChangesAsync();
            return order;
        }
        #endregion

        #region Specific Methods
        public async Task<Order> CreateOrder(BasketItem basketItem)
            => await CreateEntity(new List<BasketItem> { basketItem });

        public async Task<Order> CreateOrder(IEnumerable<BasketItem> basketItems)
            => await CreateEntity(basketItems);

        public async Task DeleteOrderById(int orderId)
        {
            await DeleteEntityCollection(order => order.OrderId == orderId);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var enumerableOrderList = await GetEntityCollection(order => order.OrderId == orderId);
            return enumerableOrderList.First();
        }

        public async Task<Order> UpdateOrderById(int orderId, OrderStatus status)
            => await UpdateEntity(order => order.OrderId == orderId, status);
        #endregion

        #region Helper Methods
        private string GenerateUniqueOrderNumber()
        {
            Func<string> generateTrackingCode = () =>
            {
                var randGen = new Random();
                var code = randGen.Next(1, 100000);

                string orderNumber = "OR" + code.ToString().PadLeft(6, '0');

                return orderNumber;
            };

            Predicate<string> codeExistInDatabase = (potentialCode) =>
            {
                var existingCode = _context.Orders
                .Where(order => order.OrderNumber == potentialCode)
                .FirstOrDefaultAsync();

                if (existingCode == null)
                    return false;
                else return true;
            };

            var potentialCode = generateTrackingCode();
            while (codeExistInDatabase(potentialCode))
            {
                potentialCode = generateTrackingCode();
            }

            return potentialCode;
        }
        private decimal CalculateTotalPriceOfBasketItems(IEnumerable<BasketItem> basketItems)
        {
            decimal totalPrice = 0;
            foreach (var basketItem in basketItems)
            {
                totalPrice += basketItem.Quantity * basketItem.Item.Product.Price;
            }

            return totalPrice;
        }
        #endregion
    }
}
