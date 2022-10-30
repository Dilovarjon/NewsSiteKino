using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
namespace NewsSite.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ApplicationContext db;
        public LoginServices(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<string> PersonLogin(HttpContext context)
        {
            var form = context.Request.Form;

            if (!form.ContainsKey("login") && !form.ContainsKey("password"))
            {
                return "/Login";
            }
            

            string login = form["login"];
            string password = form["Password"];

            if (db.Persons.FirstOrDefault(x => x.Login == login) != null && db.Persons.FirstOrDefault(x=>x.Password == password) != null)
            {
                var claims = new List<Claim>
                {
                    //new Claim()
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await context.SignInAsync(claimPrincipal);
                return "";
            }
            else
            {
                return "/Login";
            }
        }
    }
}
