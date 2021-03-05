using System;
using System.Threading.Tasks;
using Melodie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Melodie.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;

        public UserController(
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(AspNetUser user)
        {
            // The model isn't valid
            if (!ModelState.IsValid || user.Password != user.PasswordConfirmation)
            {
                ModelState.AddModelError("registerFailed", "Veuillez corriger les erreurs ci-dessous:");

                if (user.Password != user.PasswordConfirmation)
                {
                    ModelState.AddModelError("passwordsDontMatch", "Les mots de passes ne correspondent pas.");
                }
                
                return View("Register", user);
            }
            
            // Try to log in the user
            var result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            // Uh oh, something went wrong
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return View("Register", user);
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(AspNetUser user, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, lockoutOnFailure: false);
                
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }
                /*if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }*/
                if (result.IsLockedOut)
                {
                    return BadRequest("Lockout");
                }

                ModelState.AddModelError("loginFailed", "Mauvais nom d'utilisateur/mot de passe.");
                return View("Login", user);
            }
            
            return View("Login", user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOffUser()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login), "User");
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}