using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Mobiroller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           var result=  _userService.GetAll();
            return Ok(result);
        }
    }
}
