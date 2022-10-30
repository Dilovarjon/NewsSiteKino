namespace NewsSite.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly ApplicationContext db;
        public RegistrationServices(ApplicationContext db)
        {
            this.db = db;
        }
        public Person? RegistrationUsers(HttpContext context)
        {
            var person = new Person();
            var form = context.Request.Form;
            if (form != null)
            {
                /*if (db.Persons.FirstOrDefault(x => x.Login == form["login"], null) == null)
                {*/
                    person.Login = form["login"];
                    person.Password = form["password"];
                    person.PhoneNumber = form["PhoneNumber"];
                    person.Name = form["name"];
                    person.Age = form["age"];
                    person.Role = db.Roles.FirstOrDefault(x => x.Name == "User");
                    db.Add(person);
                    db.SaveChanges();

                    return person;
                /*}
                else
                    return null;*/
            }
            else
            {
                return null;
            }
        }
    }
}
