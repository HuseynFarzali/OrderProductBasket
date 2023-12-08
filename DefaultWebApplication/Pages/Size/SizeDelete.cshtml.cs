using DefaultWebApplication.Pages.Product;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Size
{
    public class SizeDeleteModel : PageModel
    {
        private readonly SizeRepository _repository;

        public SizeDeleteModel(SizeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            await _repository.DeleteSizeById(id);
            return RedirectToPage("sizemain");
        }
    }
}
