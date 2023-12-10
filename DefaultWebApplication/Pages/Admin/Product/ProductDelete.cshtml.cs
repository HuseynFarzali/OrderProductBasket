using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Product
{
    public class ProductDeleteModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public ProductDeleteModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGet([FromRoute] int id)
        {
            await _productRepository.DeleteProductById(id);
            return RedirectToPage("productmain");
        }
    }
}
