using Microsoft.AspNetCore.Mvc;

namespace DefaultWebApplication.Controllers.Exposed.User
{
    [Route("/account")]
    public class UserAccountCreateController : AccountController
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
