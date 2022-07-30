using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Mobiroller.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {

            var resutl = _authenticationService.Login(user);
            return Ok(resutl);
        }

        [HttpPost("register")]
        public IActionResult Register(Users user)
        {

            var resutl = _authenticationService.Register(user);
            return Ok(resutl);
        }
    }
}
