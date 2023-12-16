using DefaultWebApplication.Models.Domain_Models.Main_Models;
using DefaultWebApplication.Services.Authentication_Services;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserRepository _repository;
        private readonly UserManager _userManager;

        public IndexModel(ILogger<IndexModel> logger, UserRepository repository, UserManager userManager)
        {
            _logger = logger;
            _repository = repository;
            _userManager = userManager;
        }

        public Models.Domain_Models.Main_Models.User CurrentUser { get; set; }
        public bool HasAdminAccess { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var userPrincipal = (await _userManager.GetCurrentLoggedUserAsync());
            CurrentUser = userPrincipal.User;
            HasAdminAccess = userPrincipal.HasAdminAccess;

            return Page();
        }
    }
}
