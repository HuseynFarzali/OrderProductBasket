using DefaultWebApplication.Attributes;
using DefaultWebApplication.Database;
using DefaultWebApplication.Extensions;
using DefaultWebApplication.Models.Command_Models;
using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories.Main_Model_Repositories
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class ProductRepository : IRepository<Product, ProductCommandModel>
    {
        #region Properties and Service Instances
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Interface Methods
        public async Task<Product> CreateEntity(ProductCommandModel command)
        {
            var product = new Product
            {
                Name = command.ProductName,
                TagName = command.ProductTagName ?? GenerateProductTagName(command),
                Price = command.ProductPrice,
                Rating = command.ProductRating,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteEntityCollection(Func<Product, bool> criteria)
        {
            var matchingProducts = await _context.Products.ToListAsync();
            matchingProducts = matchingProducts.Where(criteria).ToList();

            foreach (var matchingProduct in matchingProducts)
            {
                matchingProduct.Deleted = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetEntityCollection(
            Func<Product, bool> criteria, bool includeItemList = false)
        {
            var matchingProductsQueryable = _context.Products.AsQueryable();

            if (includeItemList is true)
                matchingProductsQueryable = matchingProductsQueryable.Include(p => p.ItemList);

            var matchingProducts = await matchingProductsQueryable.ToListAsync();
            return matchingProductsQueryable.Where(criteria);
        }

        public async Task<Product> UpdateEntity(Func<Product, bool> criteriaUnique, ProductCommandModel command)
        {
            var matchingProducts = await _context.Products.ToListAsync();
            matchingProducts = matchingProducts.Where(criteriaUnique).ToList();

            if (matchingProducts.Count > 1)
                throw new Exception("Given criteria does not uniquely define a single entity from the context.");
            if (!matchingProducts.Any())
                throw new Exception("Given criteria is not satisfied by any entity from the context.");

            var product = matchingProducts.First();

            product.Name = command.ProductName;
            product.TagName = command.ProductTagName ?? GenerateProductTagName(command);
            product.Price = command.ProductPrice;
            product.Rating = command.ProductRating;

            await _context.SaveChangesAsync();
            return product;
        }
        #endregion

        #region Specific Methods
        public async Task<Product> CreateProduct(ProductCommandModel command)
            => await CreateEntity(command);
        
        public async Task DeleteProductById(int productId)
        {
            await DeleteEntityCollection(product => product.ProductId == productId);
        }

        public async Task<Product> GetProductById(int productId, bool includeItemList = false)
        {
            var enumerableProductList = await GetEntityCollection(
                product => product.ProductId == productId, includeItemList);
            return enumerableProductList.First();
        }

        public async Task<Product> UpdateProductById(int productId, ProductCommandModel command)
            => await UpdateEntity(product => product.ProductId == productId, command);
        #endregion

        #region Helper Methods
        private string GenerateProductTagName(ProductCommandModel command)
        {
            return command.ProductName[0..3];
        }
        #endregion
    }
}
