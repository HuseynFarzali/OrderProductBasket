using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Product
{
    public class ProductMainModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public ProductMainModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductSummaryViewModel> ProductSummaries { get; set; } = new List<ProductSummaryViewModel>();

        public async Task OnGet(bool showDeleted)
        {
            var products = await _productRepository.GetEntityCollection(p => true);

            if (!showDeleted)
                products = products.Where(p => p.Deleted == false);

            foreach (var product in products)
                ProductSummaries.Add(
                    new ProductSummaryViewModel
                    {
                        ProductId = product.ProductId,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        ProductTagName = product.TagName,
                        ProductDeleted = product.Deleted,
                    });
        }       
    }
}
