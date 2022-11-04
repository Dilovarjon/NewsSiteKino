using NewsSite.Models;

namespace NewsSite.Services.AdminServices.IAdminServices.IUserServices
{
    public interface IUserUpdateService
    {
        public Task UserUpdate(User user);
    }
}
