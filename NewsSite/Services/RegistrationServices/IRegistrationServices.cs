using NewsSite.Models;

namespace NewsSite.Services.RegistrationServices
{
    public interface IRegistrationServices
    {
        public Task<User> UserRegistration(HttpContext context);
    }
}
