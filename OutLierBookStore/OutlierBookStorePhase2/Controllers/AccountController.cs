using Microsoft.AspNetCore.Mvc;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountOperations _accountOperations;

        public AccountController(IAccountOperations accountOperations)
        {
            _accountOperations = accountOperations;
        }


        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUser User)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountOperations.CreateUser(User);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(User);
                }
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignIn user,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountOperations.PasswordSignIn(user);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                 
                    return RedirectToAction("Index", "Home");
                    
                    
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(user);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountOperations.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePassword user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountOperations.ChangePasswordAsync(user);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(user);
        } 

    }
}
