using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Category
{
    public class CategoryAddModel : PageModel
    {
        private readonly CategoryRepository _repository;

        public CategoryAddModel(CategoryRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public CategoryCommandModel CreateCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _repository.CreateCategory(CreateCommand);
            return RedirectToPage("categorymain");
        }
    }
}
