using DefaultWebApplication.Attributes;
using DefaultWebApplication.Models.Domain_Models.Main_Models;
using DefaultWebApplication.Services.Repositories.Main_Model_Repositories;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Authentication_Services
{
    [CustomService(Lifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
    public class UserManager
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserRepository _userRepository;

        public UserManager(IHttpContextAccessor contextAccessor, UserRepository userRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
        }

        public async Task<(User User, bool HasAdminAccess)> GetCurrentLoggedUserAsync()
        {
            var currentUserPrincipal = _contextAccessor.HttpContext.User;

            if (currentUserPrincipal.Claims.Count() == 0) return (null, false);

            var loggedUserId = currentUserPrincipal.FindFirst(claim => claim.Type == "UserId").Value;
            var user = await _userRepository.GetUserById(int.Parse(loggedUserId));

            var userHasAdminAccess = currentUserPrincipal.FindFirst(claim => claim.Type == "HasAdminAccess")?.Value
                ?? "false";
            var hasAdminAccess = bool.Parse(userHasAdminAccess);

            return (user, hasAdminAccess);
        }
    }
}
