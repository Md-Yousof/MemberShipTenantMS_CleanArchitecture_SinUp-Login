﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemberShipTenantMS_CleanArchitecture_Apo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
            [HttpGet("employees")]
            public IEnumerable<string> Get()
            {
                return new List<string> { "Ahmed", "Ali", "Ahsan", "Yousof", "Iftekhar Ahmend Joy" };
            }
        
    }
}
