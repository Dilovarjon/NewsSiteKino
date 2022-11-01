using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.Services.AdminServices;

namespace NewsSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IFileMovieAddServices _fileAdd;
        public AdminController(IFileMovieAddServices file)
        {
            _fileAdd = file;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileMovieAdd(IFormFile uploadedFile)
        {
            await _fileAdd.FileMovieAdd(HttpContext, uploadedFile);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> FileMoviePut()
        {
            await HttpContext.Response.WriteAsync("qweqwe");
            return Ok();
        }
    }
}
