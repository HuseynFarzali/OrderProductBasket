using DefaultWebApplication.Attributes;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Authentication_Services
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class SignInManager
    {
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpContext _httpContext;
        private readonly UserManager _userManager;

        public SignInManager(UserRepository userRepository, IHttpContextAccessor contextAccessor, UserManager userManager)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
            _httpContext = _contextAccessor.HttpContext;
            _userManager = userManager;
        }

        public async Task<User> GetMatchingUser(string email, string password, ModelStateDictionary modelState)
        {
            var matchingUsersToIdentifier = await _userRepository.GetEntityCollection(user =>
                user.Email == email);

            if (!matchingUsersToIdentifier.Any())
            {
                modelState.AddModelError(
                    key: "Invalid-identifier",
                    errorMessage: "Provided identifier do not match any user from the context.");

                return null;
            }

            var matchingUser = matchingUsersToIdentifier.Where(user =>
                user.Password == password).SingleOrDefault();

            if (matchingUser is null)
            {
                modelState.AddModelError(
                    key: "Invalid-secret",
                    errorMessage: "Provided secret do not match any user from the context.");

                return null;
            }

            return matchingUser;
        }

        public async Task SignIn(User user, bool seekNewAdminUser = true)
        {
            var idClaim = new Claim(
                type: nameof(user.UserId),
                value: user.UserId.ToString());

            var emailClaim = new Claim(
                type: nameof(user.Email),
                value: user.Email);

            var passwordClaim = new Claim(
                type: nameof(user.Password),
                value: user.Password);

            var claimsIdentity = new ClaimsIdentity(
                claims: new List<Claim> { idClaim, emailClaim, passwordClaim });

            if (seekNewAdminUser && user.Password.EndsWith("_admin_"))
            {
                var adminAccessClaim = new Claim(
                    type: "HasAdminAccess",
                    value: true.ToString());

                claimsIdentity.AddClaim(adminAccessClaim);
            }

            var claimsPrincipal = new ClaimsPrincipal(identity: claimsIdentity);

            await _httpContext.SignInAsync("Cookies", claimsPrincipal);
        }

        public void LogCurrentUserOut()
        {
            _httpContext.User = null;
        }
    }
}
