using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.Services.AdminServices.IAdminServices;

namespace NewsSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _dbContext;
        private readonly IFileMovieAddServices _fileAdd;
        private readonly IFileMovieСhangesServices _fileMovieChanges;
        private readonly IFileMovieDeleteServices _fileMovieDelete;
        public AdminController(IFileMovieAddServices fileAdd,IFileMovieСhangesServices fileMovieСhanges,IFileMovieDeleteServices fileMovieDelete, ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _fileAdd = fileAdd;
            _fileMovieChanges = fileMovieСhanges;
            _fileMovieDelete = fileMovieDelete;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetListMovie()
        {
            var list = _dbContext.Movies.Select(x => new { x.Id, x.Name, x.Path, x.Category, x.Genres, x.Opisanie }).ToList();
            return Json(list);
        }
        [HttpPost]
        public async Task<IActionResult> FileMovieAdd(IFormFile uploadedFile)
        {
            await _fileAdd.FileMovieAdd(HttpContext, uploadedFile);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> FileMovieСhanges(Movie movieData)
        {
            await _fileMovieChanges.FileMovieСhanges(movieData);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> FileMovieDelete(Movie movieData)
        {
            await _fileMovieDelete.FileMovieDelete(movieData);
            return Ok();
        }
    }
}
