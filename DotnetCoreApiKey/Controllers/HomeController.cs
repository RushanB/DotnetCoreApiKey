using System;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreApiKey.Controllers
{
    [Route("api/[controller]")]
    public class HelloController : Controller
    {
        // GET values
        [HttpGet]
        public object Get()
        {
            return new { message = $"Hello, {Request.HttpContext.User.FindFirst(c => c.Type == "UserName").Value}" };
        }
    }
}
