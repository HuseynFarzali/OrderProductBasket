using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Color
{
    public class ColorDeleteModel : PageModel
    {
        private readonly ColorRepository _repository;

        public ColorDeleteModel(ColorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet([FromRoute] int id)
        {
            await _repository.DeleteColorById(id);
            return RedirectToPage("colormain");
        }
    }
}
