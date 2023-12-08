using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Controllers.Admin.Product
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("", Name = "product-main-page")]
        [HttpGet("list", Name = "product-list-page")]
        public async Task<IActionResult> Index(bool showDeleted)
        {
            var products = await _productRepository.GetEntityCollection(p => true);

            if (!showDeleted)
            {
                products = products.Where(p => p.Deleted == false);
            }

            List<ProductSummaryViewModel> productSummaryViewModels
                = new List<ProductSummaryViewModel>();

            foreach (var product in products)
            {
                productSummaryViewModels.Add(
                    new ProductSummaryViewModel
                    {
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        ProductTagName = product.TagName,
                    });
            }

            return View("Views/Product/Main.cshtml", productSummaryViewModels);
        }
    }
}
