using NewsSite.Controllers;
using NewsSite.Models;
using NewsSite.Services.AdminServices.IAdminServices.IFileMovieServices;

namespace NewsSite.Services.AdminServices.AdminServices.FileMovieServices
{
    public class FileMovieDeleteServices : IFileMovieDeleteServices
    {
        private readonly ApplicationContext _dbContext;
        public FileMovieDeleteServices(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task FileMovieDelete(Movie movieData)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == movieData.Id);
            if (movie != null)
            {
                var file = new FileInfo(movie.Path);
                file.Delete();
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();

                return; // успешно
            }
            return; // ошибка
        }
    }
}
