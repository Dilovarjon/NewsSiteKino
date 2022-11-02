using NewsSite.Models;

namespace NewsSite.Services.AdminServices.IAdminServices
{
    public interface IFileMovieDeleteServices
    {
        public Task FileMovieDelete(Movie movieData);
    }
}
