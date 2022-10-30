using Microsoft.AspNetCore.Mvc;

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
            var res = await _loginServices.PersonLogin(HttpContext);
            if (res == "/Login")
            {
                return View();
            }
            else
                return Ok("qwe");
        }
    }
}
