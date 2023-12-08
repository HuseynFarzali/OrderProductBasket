using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Color
{
    public class ColorAddModel : PageModel
    {
        private readonly ColorRepository _repository;

        public ColorAddModel(ColorRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ColorCommandModel CreateCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await _repository.CreateColor(CreateCommand);
            return RedirectToPage("colormain");
        }
    }
}
