using DefaultWebApplication.Models.Command_Models.Main_Models;
using DefaultWebApplication.Models.View_Models.Detailed_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.User
{
    public class UserUpdateModel : PageModel
    {
        private readonly UserRepository _repository;

        public UserUpdateModel(UserRepository repository)
        {
            _repository = repository;
        }

        public UserDetailedViewModel ShowModel { get; set; }

        [BindProperty]
        public UserCommandModel UpdateCommand { get; set; }

        public async Task OnGet([FromRoute] int id)
            => await PopulateShowModel(id);

        public async Task<IActionResult> OnPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                await PopulateShowModel(id);
                return Page();
            }

            await _repository.UpdateUserById(id, UpdateCommand);
            return RedirectToPage("usermain");
        }

        private async Task PopulateShowModel(int userId)
        {
            var user = await _repository.GetUserById(userId);
            ShowModel = new UserDetailedViewModel
            {
                UserId = user.UserId,
                UserAge = user.Age,
                UserSurname = user.Surname,
                UserEmail = user.Email,
                UserName = user.Name,
                UserPassword = user.Password,
                UserTagName = user.TagName,
            };
        }
    }
}
