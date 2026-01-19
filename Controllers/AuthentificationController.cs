using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GestionMouvementCarte.Dtos;
using GestionMouvementCarte.Models;

namespace GestionMouvementCarte.Controllers
{
    public class AuthentificationController: Controller
    
    {
        private readonly SignInManager<Employe> _signInManager;
        private readonly UserManager<Employe> _userManager;

        public AuthentificationController(SignInManager<Employe> signInManager, UserManager<Employe> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Auth/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
           

            return View(model);
        }

        // GET: /Auth/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Auth/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //// POST: /Auth/ChangePassword
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        if (user != null)
        //        {
        //            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                await _signInManager.RefreshSignInAsync(user);
        //                return RedirectToAction("Index", "Home");
        //            }
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }
        //    return View(model);
        //}

        //// GET: /Auth/Profile
        //[HttpGet]
        //public async Task<IActionResult> Profile()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return RedirectToAction("Login");
        //    }
        //    var model = new ProfileModel
        //    {
        //        Nom = user.Nom,
        //        Prenom = user.Prenom,
        //        Email = user.Email
        //    };
        //    return View(model);
        //}
    }
}