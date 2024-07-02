using Microsoft.AspNetCore.Mvc;
using MigrationService.Interfaces;

namespace MigrationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtractionController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ExtractionController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpGet("{idProcesso}/{procedureName}/{outputFormat}")]
        public async Task<IActionResult> Process(int idProcesso, string procedureName, string outputFormat, [FromQuery] Dictionary<string, object> parameters)
        {
            var outputPath = $"C:\\Output\\{procedureName}_{idProcesso}.{outputFormat.ToLower()}";
            await _processService.ProcessAsync(idProcesso, procedureName, parameters, outputPath, outputFormat);
            return Ok(new { Message = "Process completed", OutputPath = outputPath });
        }

        [HttpGet("DataModels/{idProcesso}")]
        public async Task<IActionResult> GetDataModels(int idProcesso)
        {
            var dataModels = await _processService.GetDataModelsAsync(idProcesso);
            return Ok(dataModels);
        }
    }
}
