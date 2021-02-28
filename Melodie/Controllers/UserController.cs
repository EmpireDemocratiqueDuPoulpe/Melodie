using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Melodie.Data;
using Melodie.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private string _scheme = CookieAuthenticationDefaults.AuthenticationScheme;
        private Dictionary<string, string> _registerError = new();
        private Dictionary<string, string> _loginError = new();

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
            if (_registerError.Count > 0)
            {
                ViewBag.RegisterError = _registerError;
                _registerError.Clear();
            }
            
            ViewBag.Title = "Inscription";
            
            return View();
        }

        //User/Login
        [AllowAnonymous]
        [Route("User/Login")]
        public IActionResult Login()
        {
            if (_loginError.Count > 0)
            {
                ViewBag.LoginError = _loginError;
                _loginError.Clear();
            }

            ViewBag.Title = "Connexion";
            
            return View();
        }

        [AllowAnonymous]
        [HttpPost("User/ProcessLogin")]
        public async Task<IActionResult> LoginUser(User user)
        {
            var userId = await _dbService.GetUserId(user.Username);
            
            if (userId == null)
            {
                _loginError.Add("UnknownUsername", "Le nom d'utilisateur n'existe pas.");
                return RedirectToAction("Login", "User");
            }

            user.UserId = userId;
            if (!await IsUserPassword((int) user.UserId, user.Password))
            {
                _loginError.Add("WrongPassword", "Le mot de passe est erroné.");
                return RedirectToAction("Login", "User");
            }
            
            var userClaim = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    },
                    _scheme
                )
            );
            
            SignIn(userClaim, _scheme);

            return RedirectToAction("Index", "Home");
        }
        
        //User/Disconnect
        [AllowAnonymous]
        [Route("User/Disconnect")]
        public async Task<IActionResult> Disconnect()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "User");
        }
        
        /* ADD
        -------------------------------------------------- */

        [AllowAnonymous]
        [HttpPost("User/ProcessRegister")]
        public async Task<IActionResult> AddUser(User user)
        {
            // Check username
            if (!await IsUsernameAvailable(user.Username))
            {
                _registerError.Add("InvalidUsername", "Nom d'utilisateur invalide où déjà utilisé.");
            }
            
            // Check email
            if (!await IsEmailAvailable(user.EmailAddress))
            {
                _registerError.Add("InvalidEmail", "Adresse email invalide où déjà utilisée.");
            }
            
            // Check password
            if (!IsPasswordPairIdentical(user.Password, user.PasswordConfirmation))
            {
                _registerError.Add("PasswordsDontMatch", "Les mots de passe sont différents.");
            }
            else
            {
                if (!IsPasswordValid(user.Password))
                {
                    _registerError.Add("InvalidPassword", "Le mot de passe n'est pas sécurisé (8 caractères, 1 majuscule, 1 minuscule, 1 chiffre, 1 caractère spécial");
                }
            }
            
            // Redirect if there's errors
            if (_registerError.Count > 0)
            {
                return RedirectToAction("Register", "User");
            }
            
            // Add user
            await _dbService.AddUser(user);

            return await LoginUser(user);
        }
        
        /* Checks
        -------------------------------------------------- */

        private async Task<bool> IsUsernameAvailable(string username)
        {
            if (username.Length == 0 || username.Length > 32) return false;

            return await _dbService.SearchForUsername(username) == null;
        }
        
        private async Task<bool> IsEmailAvailable(string email)
        {
            if (email.Length == 0 || email.Length > 320) return false;

            return await _dbService.SearchForEmail(email) == null;
        }

        private bool IsPasswordPairIdentical(string password1, string password2)
        {
            return (password1.Equals(password2));
        }
        
        // TODO: Make this
        private bool IsPasswordValid(string password)
        {
            return true;
        }

        private async Task<bool> IsUserPassword(int userId, string password)
        {
            return await _dbService.IsUserPassword(userId, password);
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