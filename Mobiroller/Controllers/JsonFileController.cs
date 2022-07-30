using Business.Abstract;
using BusinessLayer.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mobiroller.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JsonFileController : Controller
    {
        IJsonFileService _jsonFileService;
        ILocalizationService _localizationService;
        public JsonFileController(IJsonFileService jsonFileService , 
            ILocalizationService localizationService)
        {
            _localizationService = localizationService;
            _jsonFileService = jsonFileService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("import")]
        public IActionResult Add(JsonFile jsonFile)
        {
            _jsonFileService.Add(jsonFile);
            return Ok();
        }

        [HttpPost("getall")]
        public IActionResult Localize(string localize , Users user)
        {
            var result = _localizationService.Localize(localize , user);
            return Ok(result);
        }
    }
}
