using Microsoft.AspNetCore.Mvc;
using OcelotAuthorization.Auth.Services;

namespace OcelotAuthorization.Auth.Controllers
{
    [Route("api")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        internal readonly JWTAuth _jWTAuth;

        public TokenController(JWTAuth jWTAuth)
        {
            _jWTAuth = jWTAuth;
        }

        [HttpPost("GenerateToken")]
        public IActionResult GenerateToken()
        {
            string[] scopes = { "blog.read" };
            string token = _jWTAuth.GetJWTToken(Guid.NewGuid().ToString(), "mglinnthithtoo@gmail.com", "admin", scopes);

            return Ok(token);
        }
    }
}
