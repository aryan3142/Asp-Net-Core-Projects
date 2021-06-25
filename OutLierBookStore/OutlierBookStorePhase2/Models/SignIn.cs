using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Models
{
    public class SignIn
    {
        [Required,EmailAddress]
        [Display(Name = "Please enter your email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="RememberMe")]
        public bool RememberMe { get; set; }
    }
}
