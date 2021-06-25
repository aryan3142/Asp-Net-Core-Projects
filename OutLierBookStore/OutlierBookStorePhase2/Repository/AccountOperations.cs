using Microsoft.AspNetCore.Identity;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using OutlierBookStorePhase2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository
{
    public class AccountOperations : IAccountOperations
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountOperations(IUserService userService,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(SignUpUser user)
        {
            var newUser = new ApplicationUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignIn(SignIn user)
        {
           var result = await _signInManager.PasswordSignInAsync(user.Email,user.Password,user.RememberMe,false);
            return result;
        }

        public async Task SignOutAsync()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePassword user)
        {
            var userId = _userService.GetUserId();
            var currentUser = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(currentUser, user.CurrentPassword, user.NewPassword);
            return result;
        } 
    }
}
