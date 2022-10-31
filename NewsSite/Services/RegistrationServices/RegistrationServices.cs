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
        public User UserRegistration(HttpContext context)
        {
            var person = new User();

            var form = context.Request.Form;
            
            var hasPerson = db.Users.Any(x => x.Login == form["login"]);
            if (form != null && !hasPerson)
            {
                    person.Login = form["login"];
                    person.Password = form["password"];
                    person.PhoneNumber = form["phonenumber"];
                    person.Name = form["name"];
                    person.Age = form["age"];
                    person.Role = db.Roles.FirstOrDefault(x => x.Name == "User");
                    db.Add(person);
                    db.SaveChanges();

                    return person;
            }
            else
            {
                return person;
            }
        }
    }
}
