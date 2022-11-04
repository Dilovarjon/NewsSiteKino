using NewsSite.Models;

namespace NewsSite.Services.AdminServices.IAdminServices.IFileMovieServices
{
    public interface IFileMovieDeleteServices
    {
        public Task FileMovieDelete(Movie movieData);
    }
}
