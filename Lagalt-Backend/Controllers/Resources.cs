using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lagalt_Backend.Controllers
{
    [Route("api/resources")]
    [ApiController]
    [Authorize]
    public class Resources : ControllerBase
    {
        [HttpGet("public")]
        [AllowAnonymous]
        public ActionResult GetPublic()
        {
            return Ok(new { Message = "Public resource" });
        }

        [HttpGet("protected")]
        public ActionResult GetProtected()
        {

            return Ok(new { Message = "Protected resource" });
        }

        [HttpGet("role")]
        [Authorize(Roles = "OWNER")]
        public ActionResult GetRole()
        {
            return Ok(new { Message = "Roles resource" });
        }

        [HttpGet("subject")]
        public ActionResult GetSubject()
        {
            var subject = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(new { Subject = subject });
        }

    }
}
