using NewsSite.Controllers;
using NewsSite.Models;

namespace NewsSite.Services.RegistrationServices
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly ApplicationContext db;
        public RegistrationServices(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<User> UserRegistration(HttpContext context)
        {
            var user = new User();

            var form = context.Request.Form;

            string login = form["login"];
            string password = form["password"];
            string phoneNumber = form["phonenumber"];
            string name = form["name"];
            string age = form["age"];

            var hasPerson = db.Users.Any(x => x.Login == login.ToLower());

            if (form != null && !hasPerson)
            {
                user.Login = login.ToLower();
                user.Password = password;
                user.PhoneNumber = phoneNumber;
                user.Name = name;
                user.Age = age;
                user.Role = db.Roles.FirstOrDefault(x => x.Name == "user");
                db.Add(user);
                await db.SaveChangesAsync();

                return user;
            }
            else
            {
                
                return null;
            }
        }
    }
}
