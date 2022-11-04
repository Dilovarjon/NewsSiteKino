using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.Services.AdminServices.IAdminServices.IFileMovieServices;
using NewsSite.Services.AdminServices.IAdminServices.IUserServices;

namespace NewsSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationContext _dbContext;
        /// <summary>
        /// Файловые DI
        /// </summary>
        private readonly IFileMovieAddServices _fileAdd;
        private readonly IFileMovieСhangesServices _fileMovieUpdate;
        private readonly IFileMovieDeleteServices _fileMovieDelete;

        private readonly IUserUpdateService _UserUpdateService;

        public AdminController
            (/*File Service*/IFileMovieAddServices fileAdd, IFileMovieСhangesServices fileMovieСhanges, IFileMovieDeleteServices fileMovieDelete,
            /*data base*/ApplicationContext dbContext,
            /*User Service*/IUserUpdateService userUpdate)
        {
            _dbContext = dbContext;
            // File Service
            _fileAdd = fileAdd;
            _fileMovieUpdate = fileMovieСhanges;
            _fileMovieDelete = fileMovieDelete;
            //User Service
            _UserUpdateService = userUpdate;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Получаем список Userow
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListUsers()
        {
            var users = _dbContext.Users.Select(x => x);
            return Ok();
        }
        /// <summary>
        /// Получаем пользователя по id и отправляем его
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UserGet(User user)
        {
            // получаем пользователя по Id
            var users = _dbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            // если не найден, отправляем статусный код и сообщение об ошибке
            if(users != null)
            {
                return RedirectToAction("UserUpdate", users);
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UserUpdate(User user)
        {
            await _UserUpdateService.UserUpdate(user);
            return Ok();
        }

        /// <summary>
        /// Получаем Список(list) Фильмов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListMovie()
        {
            var list = _dbContext.Movies.Select(x => x).ToList();
            return Json(list);
        }
        /// <summary>
        /// Добовляем Фильмы на сайт ( добовляем в базу данных и на сервер/в папку Movies)
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> FileMovieAdd(IFormFile uploadedFile)
        {
            await _fileAdd.FileMovieAdd(HttpContext, uploadedFile);
            return Ok();
        }
        /// <summary>
        /// Изменяем Имя, Описание, Категории, Жанры
        /// </summary>
        /// <param name="movieData"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> FileMovieСhanges(Movie movieData)
        {
            await _fileMovieUpdate.FileMovieСhanges(movieData);
            return Ok();
        }
        /// <summary>
        /// Метод удаления Фильма
        /// </summary>
        /// <param name="movieData"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> FileMovieDelete(Movie movieData)
        {
            await _fileMovieDelete.FileMovieDelete(movieData);
            return Ok();
        }
    }
}
