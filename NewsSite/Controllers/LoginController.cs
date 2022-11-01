using Microsoft.AspNetCore.Mvc;
using NewsSite.Services.LoginServices;

namespace NewsSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Check()
        {
            string res = await _loginServices.PersonLogin(HttpContext);
            
            return Redirect(res);
        }
    }
}
