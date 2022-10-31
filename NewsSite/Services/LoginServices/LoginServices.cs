using Microsoft.AspNetCore.Authentication;
using NewsSite.Controllers;
using System.Security.Claims;
namespace NewsSite.Services.LoginServices
{
    public class LoginServices : ILoginServices
    {
        private readonly ApplicationContext _dbContext;
        public LoginServices(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> PersonLogin(HttpContext context)
        {
            var form = context.Request.Form;

            string login = form["login"];
            string password = form["Password"];

            var hasPerson = _dbContext.Users.Any(x => x.Login == login && x.Password == password);

            if (!form.ContainsKey("login") && !form.ContainsKey("password"))
            {
                return "/Login";
            }



            if (hasPerson)
            {
                var claims = new List<Claim>
                {
                    //new Claim()
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await context.SignInAsync(claimPrincipal);

                return string.Empty;
            }
            else
            {
                return "/Login";
            }
        }
    }
}
