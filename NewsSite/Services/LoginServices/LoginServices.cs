using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
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

            var hasPerson = _dbContext.Users.Any(x => x.Login == login.ToLower() && x.Password == password);

            if (!form.ContainsKey("login") && !form.ContainsKey("password"))
            {
                return "/Login";
            }

            if (hasPerson)
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
                var role = await _dbContext.Users.Where(x => x.Login == login && x.Password == password).Include(x=>x.Role).FirstOrDefaultAsync(x => x.Password == password);
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType,user!.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,role!.Role!.Name)
                };
                var claimIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await context.SignInAsync(claimPrincipal);

                return "/Admin";
            }
            else
            {
                return "/Login";
            }
        }
    }
}
