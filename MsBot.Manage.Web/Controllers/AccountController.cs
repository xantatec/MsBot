using Microsoft.AspNetCore.Mvc;

namespace MsBot.Manage.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
