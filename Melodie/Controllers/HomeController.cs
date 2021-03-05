using System.Diagnostics;
using System.Threading.Tasks;
using Melodie.Data;
using Microsoft.AspNetCore.Mvc;
using Melodie.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Melodie.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IMelodieDbService _dbService;

        public HomeController(IMelodieDbService service)
        {
            _dbService = service;
        }
        
        /* GET
        -------------------------------------------------- */
        //Home/Index/
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var playlists = await _dbService.GetPlaylistsOf(User.Identity.GetUserId());
            var lastMusics = await _dbService.GetLastMusics();

            if (playlists.Equals(default)) return RedirectToAction(nameof(Error));

            ViewBag.Title = "Home Page";
            ViewBag.Playlists = playlists;
            ViewBag.LastMusics = lastMusics;

            return View();
        }
        
        public IActionResult ChangeTheme(string url)
        {
            if (HttpContext.Request.Cookies.Keys.Contains("theme"))
            {
                var currentTheme = HttpContext.Request.Cookies["theme"];

                HttpContext.Response.Cookies.Append("theme",
                    currentTheme == "dark-theme" ? "light-theme" : "dark-theme");
            }
            else
            {
                HttpContext.Response.Cookies.Append("theme", "light-theme");
            }

            return Redirect(url);
        }

        /* Error
        -------------------------------------------------- */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
