using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Category
{
    public class CategoryMainModel : PageModel
    {
        private readonly CategoryRepository _repository;

        public CategoryMainModel(CategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategorySummaryViewModel> CategorySummaries { get; set; } = new List<CategorySummaryViewModel>();

        public async Task OnGet(bool showDeleted)
        {
            var categories = await _repository.GetEntityCollection(c => true);

            if (!showDeleted)
                categories = categories.Where(c => c.Deleted == false);

            foreach (var category in categories)
            {
                CategorySummaries.Add(
                    new CategorySummaryViewModel
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.Name,
                        CategoryTagName = category.TagName,
                        CategoryDeleted = category.Deleted,
                    });
            }
        }
    }
}
