using ApiCleanArchitecture.Application.UseCases;
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
        private readonly PessoaFisicaUseCase _pessoaFisicaUseCase;
        public PessoaFisicaController(PessoaFisicaUseCase pessoaFisicaUseCase)
        {
            _pessoaFisicaUseCase = pessoaFisicaUseCase;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Index()
        {
            var result = await _pessoaFisicaUseCase.GetAllCirculacaoInterna();
            return Ok(result);
        }
    }
}
