using NewsSite.Controllers;
using NewsSite.Models;

namespace NewsSite.Services.AdminServices
{
    public class FileMovieAddServices : IFileMovieAddServices
    {
        private readonly ApplicationContext _dbContext;
        private readonly IWebHostEnvironment _appEnvironment;
        public FileMovieAddServices(ApplicationContext dbContext, IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
        }

        public async Task FileMovieAdd(HttpContext context, IFormFile uploadedFile)
        {
            var form = context.Request.Form;

            string name = form["name"];
            string gen = form["genres"];
            string cat = form["category"];
            string opistanie = form["opisatie"];

            var genres = _dbContext.Genres.FirstOrDefault(x => x.Name == gen);
            var category = _dbContext.Categories.FirstOrDefault(x => x.Name == cat);

            // Берём формат файла и соединяем с новым именем файла
            name = name + uploadedFile.FileName.Substring(uploadedFile.FileName.LastIndexOf('.'));
            if (uploadedFile != null && uploadedFile.Length <= 2200000000)
            {
                // путь к папке Files
                string path = "/Movies/" + name;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                var file = new Movie { Name = name, Path = path, Genres = genres, Category = category, Opisanie = opistanie };
                _dbContext.Movies.Add(file);
                _dbContext.SaveChanges();
            }
        }
    }
}
