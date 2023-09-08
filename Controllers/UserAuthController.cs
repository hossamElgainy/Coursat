using Coursat.Models;
using Coursat.Data;
using Coursat.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Coursat.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public UserAuthController(AppDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel,string ReturnUrl=null)
        {
            loginModel.LoginInValid = "true";
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.Email,
                                                                      loginModel.Password,
                                                                      loginModel.RememberMe,
                                                                      lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    loginModel.LoginInValid = "";

                    if (ReturnUrl != null)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return PartialView("_UserLoginPartial", loginModel);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string ReturnUrl = null)
        {
            await _signInManager.SignOutAsync();
            if(ReturnUrl != null)
            {
                return LocalRedirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            model.RegistrationInValid = "true";
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName    = model.Email,
                    Email       = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FirstName   = model.FirstName,
                    LastName    = model.LastName,
                    Address1    = model.Address1,
                    Address2    = model.Address2,
                    PsotCode    = model.PostCode,
                };

                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    model.RegistrationInValid = "";
                    await _signInManager.SignInAsync(user,isPersistent: false);

                    return RedirectToAction("Home/Index");
                }
                AddErrorsToMedelState(result);                  
            }
            return PartialView("_UserRegisterPartial", model);

        }
        public async Task<bool> UserNameExist(string userName)
        {
            bool userNameExist =  await _context.Users.AnyAsync(u => u.UserName.ToUpper() == userName.ToLower());
            if (userNameExist)
                return true;
            return false;
        }
        private void AddErrorsToMedelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
