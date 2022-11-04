using NewsSite.Controllers;
using NewsSite.Models;
using NewsSite.Services.AdminServices.IAdminServices;

namespace NewsSite.Services.AdminServices.AdminServices
{
    public class FileMovieСhangesServices : IFileMovieСhangesServices
    {
        private readonly ApplicationContext _dbContext;
        public FileMovieСhangesServices(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task FileMovieСhanges(Movie movieData)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == movieData.Id && x.Name == movieData.Name && x.Path == movieData.Path);
            if (movie != null)
            {
                string name = movieData.Name;
                // Берём формат файла и соединяем с новым именем файла
                name = name + movieData.Name.Substring(movieData.Name.LastIndexOf("."));
                /*uploadedFile.FileName.Substring(uploadedFile.FileName.LastIndexOf('.'))*/

                // путь к папке Files
                string path = "/Movies/" + name;
                movie.Name = movieData.Name;
                movie.Path = path;
                movie.Category = movieData.Category;
                movie.Genres = movieData.Genres;
                movie.Opisanie = movieData.Opisanie;
                _dbContext.Movies.Update(movie);
                await _dbContext.SaveChangesAsync();
                return;
            }
            else
            {
                return;
            }
        }

    }
}
