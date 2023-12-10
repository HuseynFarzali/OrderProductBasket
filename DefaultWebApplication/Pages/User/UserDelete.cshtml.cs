using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.User
{
    public class UserDeleteModel : PageModel
    {
        private readonly UserRepository _repository;

        public UserDeleteModel(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet([FromRoute] int id)
        {
            await _repository.DeleteUserById(id);
            return RedirectToPage("usermain");
        }
    }
}
