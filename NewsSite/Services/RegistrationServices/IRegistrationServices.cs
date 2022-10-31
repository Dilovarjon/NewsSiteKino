using NewsSite.Models;

namespace NewsSite.Services.RegistrationServices
{
    public interface IRegistrationServices
    {
        public User UserRegistration(HttpContext context);
    }
}
