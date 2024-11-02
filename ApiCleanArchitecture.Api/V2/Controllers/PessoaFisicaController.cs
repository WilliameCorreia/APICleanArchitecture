using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiCleanArchitecture.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PessoaFisicaController : Controller
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
