using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcuityHome.DataAccessLayer;
using AcuityHome.DataAccessLayer.Entities;
using AcuityHome.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcuityHome.Controllers.ApiControllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly AcuityHomeContext _context;
        private readonly SignInManager<StoreUser> _signInManager;

        public UsersApiController(AcuityHomeContext context, SignInManager<StoreUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<bool> Login([FromForm] LoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Username,
                model.Password,
                model.RememberMe,
                false);

            return result.Succeeded;
        }
    }
}