using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;
        private readonly IEmailService _emailService;

        public HomeController(IUserService service,IEmailService emailService)
        {
            _service = service;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            UserEmailOptions userEmailOptions = new UserEmailOptions()
            {
                ToEmails = new List<string>() { "test@gmaillook.com" }
            };
             await _emailService.SendTestEmail(userEmailOptions);


            //var userId = _service.GetUserId();

            //var IsLoggedIn = _service.IsAuthenticated();

            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
