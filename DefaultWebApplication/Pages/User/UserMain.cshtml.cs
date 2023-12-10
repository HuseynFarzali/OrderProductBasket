using DefaultWebApplication.Models.View_Models.Summary_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.User
{
    public class UserMainModel : PageModel
    {
        private readonly UserRepository _repository;

        public UserMainModel(UserRepository repository)
        {
            _repository = repository;
        }

        public List<UserSummaryViewModel> UserSummaries { get; set; } = new List<UserSummaryViewModel>();

        public async Task OnGet(bool showDeleted)
        {
            var users = await _repository.GetEntityCollection(u => true);

            if (!showDeleted)
                users = users.Where(u => u.Deleted == false);

            foreach (var user in users)
            {
                UserSummaries.Add(
                    new UserSummaryViewModel
                    {
                        UserId = user.UserId,
                        UserName = user.Name,
                        UserEmail = user.Email,
                        UserDeleted = user.Deleted,
                        UserSurname = user.Surname,
                        UserTagName = user.TagName,
                    });
            }
        }
    }
}
