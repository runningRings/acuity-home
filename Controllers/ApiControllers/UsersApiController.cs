using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcuityHome.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcuityHome.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly AcuityHomeContext _context;

        public UsersApiController(AcuityHomeContext context)
        {
            _context = context;
        }
    }
}