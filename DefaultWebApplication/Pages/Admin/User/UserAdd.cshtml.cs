using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.User
{
    public class UserAddModel : PageModel
    {
        private readonly UserRepository _repository;

        public UserAddModel(UserRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public UserCommandModel CreateCommand { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _repository.CreateUser(CreateCommand);
            return RedirectToPage("usermain");
        }
    }
}
