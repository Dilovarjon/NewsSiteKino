using NewsSite.Controllers;
using NewsSite.Models;
using NewsSite.Services.AdminServices.IAdminServices.IUserServices;

namespace NewsSite.Services.AdminServices.AdminServices.UserServices
{
    public class UserUpdateService : IUserUpdateService
    {
        private readonly ApplicationContext _dbContext;
        public UserUpdateService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UserUpdate(User user)
        {
            var users = _dbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            
            if (users != null)
            {
                users.RoleId = user.RoleId;
                _dbContext.Users.Update(users);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
