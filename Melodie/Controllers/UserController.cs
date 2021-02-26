using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Melodie.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMelodieDbService _dbService;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _loginManager;

        public UserController(
            ILogger<UserController> logger,
            IMelodieDbService service
            //UserManager<User> userManager,
            //SignInManager<User> loginManager)
            )
        {
            _logger = logger;
            _dbService = service;
            //_userManager = userManager;
            //_loginManager = loginManager;
        }

        /* GET
        -------------------------------------------------- */
        //User/Register
        [AllowAnonymous]
        [Route("User/Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        //User/Login
        [AllowAnonymous]
        [Route("User/Login")]
        public IActionResult Login()
        {
            return View();
        }
        
        //User/Logout
        //[Route("User/Logout")]
        //public IActionResult Logout()
        //{
        //    _loginManager.SignOutAsync();
        //    return RedirectToAction("Login", "User");
        //}
        
        /* ADD
        -------------------------------------------------- */
        //User/Register
        //[AllowAnonymous]
        //[HttpPost("User/Register")]
        //public async Task<IActionResult> AddUser(User user)
        //{
        //    if (user.Password != user.PasswordConfirmation)
        //    {
        //        ViewBag.RegisterError = "Les mots de passe doivent correspondre.";
        //        return RedirectToAction("Register", "User");
        //    }
        //    
        //    var userCreation = await _userManager.CreateAsync(user, user.Password);
//
        //    if (userCreation.Succeeded)
        //    {
        //        return RedirectToAction("Login", "User");
        //    }
//
        //    ViewBag.RegisterError = "Erreur lors de l'inscription";
        //    return RedirectToAction("Register", "User");
        //}
        
        //User/Login
        //[AllowAnonymous]
        //[HttpPost("User/Login")]
        //public async Task<IActionResult> LoginUser(User user)
        //{
        //    var userLogin = await _loginManager.PasswordSignInAsync(user.Username, user.Password, false, false);
//
        //    if (userLogin.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
//
        //    ViewBag.LoginError = "Erreur lors de la connexion";
        //    return RedirectToAction("Login", "User");
        //}
    }
}