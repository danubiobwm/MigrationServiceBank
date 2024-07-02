using Microsoft.AspNetCore.Mvc;
using MigrationService.Interfaces;

namespace MigrationService.Controllers
{
    [ApiController]
    [Route("api/v1/siglas")]
    public class SiglaController : ControllerBase
    {
        private readonly ISiglaService _siglaService;

        public SiglaController(ISiglaService siglaService)
        {
            _siglaService = siglaService;
        }

        [HttpGet("{sigla}")]
        public IActionResult GetSigla(string sigla)
        {
            var result = _siglaService.GetSigla(sigla);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllSiglas()
        {
            var result = _siglaService.GetAllSiglas();
            return Ok(result);
        }
    }
}
