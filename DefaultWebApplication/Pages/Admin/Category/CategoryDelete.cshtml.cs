using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Category
{
    public class CategoryDeleteModel : PageModel
    {
        private readonly CategoryRepository _repository;

        public CategoryDeleteModel(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            await _repository.DeleteCategoryById(id);
            return RedirectToPage("categorymain");
        }
    }
}
