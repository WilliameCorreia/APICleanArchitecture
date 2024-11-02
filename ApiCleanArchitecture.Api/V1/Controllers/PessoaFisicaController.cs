using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiCleanArchitecture.Api.V1.Controllers
{
    [ApiVersion("1.0")]
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
