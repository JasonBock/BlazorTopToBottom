using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController() : ControllerBase
    {
        [HttpGet]
        public IdentityData Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = new IdentityData
            {
                AuthenticationType = identity?.AuthenticationType,
                Claims = identity?.Claims.Select(c => new ClaimData
                {
                    Name = c.Type,
                    ValueType = c.ValueType,
                    Value = c.Value
                }).ToList()
            };
            return result;
        }
    }
}
