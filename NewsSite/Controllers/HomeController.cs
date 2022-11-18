using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using System.Diagnostics;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
            Console.Write(_logger);
        }
        [HttpGet]
        public IActionResult ListGetMovie()
        {
            _dbContext.Users.Select(x => x).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult GetMovie()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}