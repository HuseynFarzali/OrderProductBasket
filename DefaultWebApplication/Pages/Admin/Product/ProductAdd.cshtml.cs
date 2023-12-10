using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Product
{
    public class ProductAddModel : PageModel
    {
        private readonly ProductRepository _productRepository;

        public ProductAddModel(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public ProductCommandModel CreateCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productRepository.CreateProduct(CreateCommand);
            return RedirectToPage("productmain");
        }
    }
}
