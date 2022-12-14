using Microsoft.AspNetCore.Mvc;
using NewsSite.Services.RegistrationServices;

namespace NewsSite.Controllers
{
    public class RegistrationController : Controller
    {
           private readonly IRegistrationServices _registrationServices;
           public RegistrationController(IRegistrationServices registrationServices)
           {
               _registrationServices = registrationServices;
           }
   
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
         [HttpPost]
         public async Task<IActionResult> Check()
         {
             var registrPerson = await _registrationServices.UserRegistration(HttpContext);
             if (registrPerson != null)
                 return Redirect("/login");
             else
                 return Redirect("/registration");
         }
    }
}
