using Library_Management_System.Core;
using Library_Management_System.Model.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Accounts _accounts;

        public AccountController(Accounts accounts)
        {
            _accounts = accounts;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserModel userModel)
        {
            var result = _accounts.Signup(userModel);
            return Ok(result);
            
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(UserModel userModel)
        {
            var result = await _accounts.Login(userModel);
            return Ok(result);
        }
    }
}
