using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Size
{
    public class SizeAddModel : PageModel
    {
        private readonly SizeRepository _repository;

        public SizeAddModel(SizeRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public SizeCommandModel CreateCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _repository.CreateSize(CreateCommand);
            return RedirectToPage("sizemain");
        }
    }
}
