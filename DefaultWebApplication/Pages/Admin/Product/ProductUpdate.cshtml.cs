using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Product
{
    public class ProductUpdateModel : PageModel
    {
        private readonly ProductRepository _repository;

        public ProductUpdateModel(ProductRepository repository)
        {
            _repository = repository;
        }

        public ProductDetailedViewModel ShowModel { get; set; }

        [BindProperty]
        public ProductCommandModel UpdateModel { get; set; }

        public async Task OnGet([FromRoute] int id)
            => await PopulateShowModel(id);

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await PopulateShowModel(id);
                return Page();
            }

            await _repository.UpdateProductById(id, UpdateModel);
            return RedirectToPage("productmain");
        }

        private async Task PopulateShowModel(int productId)
        {
            var product = await _repository.GetProductById(productId);
            ShowModel = new ProductDetailedViewModel
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
                ProductRating = product.Rating,
                ProductTagName = product.TagName,
                ProductId = product.ProductId
            };
        }
    }
}
