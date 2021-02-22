using System.Diagnostics;
using System.Threading.Tasks;
using Melodie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Melodie.Models;

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
        
        /* Index
        -------------------------------------------------- */
        /* GET */
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
            
            if (playlists.Equals(default)) return RedirectToAction("Error");
            
            ViewBag.Title = "Home Page";
            ViewBag.Playlists = playlists;
            
            return View();
        }
        
        //Home/PlaylistOf/ID
        //[HttpGet("Home/PlaylistOf/{uid}", Name = "GetByUserId")]
        //public async Task<IActionResult> Playlist(int uid)
        //{
        //    var playlists = await _dbService.GetPlaylistsOf(uid);
        //    
        //    ViewBag.Title = "Playlists";
        //    ViewBag.Playlists = playlists;
//
        //    return (playlists != default) ? View() : NotFound();
        //}

        /* Playlists
        -------------------------------------------------- */
        /* GET */
        //Home/Playlist/
        [Route("Home/Playlist")]
        public IActionResult Playlist()
        {
            // TODO: Delete function?
            ViewBag.Title = "Playlist";
            return View();
        }
        
        //Home/Playlist/ID
        [HttpGet("Home/Playlist/{pid:int}", Name = "GetByPlaylistId")]
        public async Task<IActionResult> Playlist(int pid)
        {
            var playlist = await _dbService.GetPlaylistById(pid);

            if (playlist == default) return RedirectToAction("Index");
            
            ViewBag.Title = "Playlist - " + playlist.name;
            //ViewBag.Playlist = playlist;

            return View(playlist);
        }

        /* ADD */
        //Home/Playlist/Add
        [HttpPost("Home/AddPlaylist", Name = "AddPlaylist")]
        public async Task<ActionResult<Playlist>> AddPlaylist()
        {
            var playlist = new Playlist();

            var playlistId = await _dbService.AddPlaylist(playlist);
            return (playlist != default)
                //? CreatedAtRoute("GetByPlaylistId", new {pid = playlistId}, playlist)
                ? RedirectToAction("Playlist", new {pid = playlistId})
                : BadRequest();
        }
        
        //[HttpPost("Home/Playlist/Add", Name = "AddPlaylist")]
        //public async Task<ActionResult<Playlist>> AddPlaylist(Playlist playlist)
        //{
        //    if (playlist.playlist_id != null)
        //    {
        //        return BadRequest("ID cannot be set for INSERT query.");
        //    }
//
        //    var playlistId = await _dbService.AddPlaylist(playlist);
        //    return (playlist != default)
        //        ? CreatedAtRoute("GetByPlaylistId", new {pid = playlistId}, playlist)
        //        : BadRequest();
        //}
        
        /* UPDATE */
        //Home/Playlist/Update
        //[HttpPut("Home/UpdatePlaylist", Name = "UpdatePlaylist")]
        [HttpPost("Home/UpdatePlaylist", Name = "UpdatePlaylist")]
        public async Task<ActionResult<Playlist>> UpdatePlaylist(Playlist playlist)
        {
            if (playlist.playlist_id == null)
            {
                return BadRequest("ID must be set for UPDATE query.");
            }

            var result = await _dbService.UpdatePlaylist(playlist);
            return (result > 0) ? NoContent() : NotFound();
        }
        
        /* DELETE */
        //Home/Playlist/Delete/ID
        [HttpDelete("Home/Playlist/Delete/{pid}", Name = "DelPlaylist")]
        public async Task<ActionResult<Playlist>> DeletePlaylist(int pid)
        {
            var result = await _dbService.DeletePlaylist(pid);
            return (result > 0) ? NoContent() : NotFound();
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
