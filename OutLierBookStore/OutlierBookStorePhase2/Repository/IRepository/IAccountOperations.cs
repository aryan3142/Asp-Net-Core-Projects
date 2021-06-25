using Microsoft.AspNetCore.Identity;
using OutlierBookStorePhase2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository.IRepository
{
    public interface IAccountOperations
    {
        Task<IdentityResult> CreateUser(SignUpUser user);
        Task<SignInResult> PasswordSignIn(SignIn user);
        Task SignOutAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePassword user);
    }
}
