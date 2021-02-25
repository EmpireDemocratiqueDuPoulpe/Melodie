﻿using System.Diagnostics;
using System.Threading.Tasks;
using Melodie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Melodie.Models;
using Microsoft.AspNetCore.Http.Extensions;

namespace Melodie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMelodieDbService _dbService;

        public HomeController(ILogger<HomeController> logger, IMelodieDbService service)
        {
            _logger = logger;
            _dbService = service;
        }
        
        /* GET
        -------------------------------------------------- */
        //Home/Index/
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        // TODO: Update after login system
        //[HttpGet(Name = "GetByUserId")]
        //[Route("{uid}")]
        //[Route("Home/{uid}")]
        //[Route("Home/Index/{uid}")]
        //public async Task<IActionResult> Index(int uid)
        public async Task<IActionResult> Index()
        {
            var playlists = await _dbService.GetPlaylistsOf(1);
            var lastMusics = await _dbService.GetLastMusics(10);

            if (playlists.Equals(default)) return RedirectToAction("Error");

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
