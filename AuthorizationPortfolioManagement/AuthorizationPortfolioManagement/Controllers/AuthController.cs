using AuthorizationPortfolioManagement.Models;
using AuthorizationPortfolioManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationPortfolioManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IConfiguration _config;

        public AuthController(IAuthorizationService authorizationService,IConfiguration config)
        {
            _authorizationService = authorizationService;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            try
            {
                Customer customer = _authorizationService.CheckCredentials(user);
                if(customer != null)
                {
                    var tokenVal = _authorizationService.GetJWT(_config, customer);
                    return Ok(tokenVal);
                }
                return Unauthorized("Invalid Credentials");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        } 

    }
}
