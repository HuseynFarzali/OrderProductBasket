using DefaultWebApplication.Attributes;
using DefaultWebApplication.Services.Authentication_Services;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Classification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DefaultWebApplication.Pages.Client
{
    public class LoginModel : PageModel
    {
        private readonly UserRepository _repository;
        private readonly SignInManager _signInManager;
        private readonly UserManager _userManager;

        public LoginModel(UserRepository repository, SignInManager signInManager, UserManager userManager)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var foundUser = await _signInManager.GetMatchingUser(
                email: Input.Email,
                password: Input.Password,
                modelState: ModelState);

            if (foundUser is null) return Page();

            _signInManager.LogCurrentUserOut();
            await _signInManager.SignIn(user: foundUser);

            return RedirectToPage("../Index");
        }

        public class InputModel
        {
            [Display(Name = "Your email")]
            [Required(ErrorMessage = "User email should be provided")]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "Your password")]
            [Required(ErrorMessage = "User password should be provided.")]
            [Password(CapitalLetterRequired = false, RequiredLength = 4, ErrorMessage = "{0} is not correct format of {1}")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
