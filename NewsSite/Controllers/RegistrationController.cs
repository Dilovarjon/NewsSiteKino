using Microsoft.AspNetCore.Mvc;

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
         public IActionResult Check()
         {
             var registrPerson = _registrationServices.RegistrationUsers(HttpContext);
             if (registrPerson != null)
                 return Redirect("/login");
             else
                 return View("/");
         }
    }
}
