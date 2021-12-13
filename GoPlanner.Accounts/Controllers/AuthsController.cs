using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace GoPlanner.Accounts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthsController : ControllerBase
    {
        private readonly ILogger<AuthsController> _logger;

        public AuthsController(ILogger<AuthsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(bool), description: "Login successful")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, type: typeof(bool), description: "Invalid login credentials")]
        public IActionResult Authenticate(string username, string password)
        {
            _logger.LogInformation("Starting to authenticate");

            var isAuthenticated = username == "admin" && password == "pass";

            return isAuthenticated ? Ok(true) : Unauthorized(false);
        }
    }
}
