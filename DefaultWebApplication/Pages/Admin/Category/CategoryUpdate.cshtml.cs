using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Category
{
    public class CategoryUpdateModel : PageModel
    {
        private readonly CategoryRepository _repository;

        public CategoryUpdateModel(CategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryDetailedViewModel ShowModel { get; set; }

        [BindProperty]
        public CategoryCommandModel UpdateModel { get; set; }

        public async Task OnGet([FromRoute] int id)
            => await PopulateShowModel(id);

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await PopulateShowModel(id);
                return Page();
            }            

            await _repository.UpdateCategoryById(id, UpdateModel);

            return RedirectToPage("categorymain");
        }

        private async Task PopulateShowModel(int categoryId)
        {
            var category = await _repository.GetCategoryById(categoryId);
            ShowModel = new CategoryDetailedViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.Name,
                CategoryTagName = category.TagName,
            };
        }
    }
}
