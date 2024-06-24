using Microsoft.AspNetCore.Mvc;
using MigrationService.Services;

namespace MigrationService.Controllers
{
    [Route("api/v1/extraction")]
    [ApiController]
    public class ExtractionController : ControllerBase
    {
        private readonly IExtractionService _extractionService;

        public ExtractionController(IExtractionService extractionService)
        {
            _extractionService = extractionService;
        }

        [HttpGet("fetch-data")]
        public async Task<IActionResult> FetchData()
        {
            var data = await _extractionService.FetchDataAsync();
            return Ok(data);
        }

        [HttpGet("read-data")]
        public async Task<IActionResult> ReadData()
        {
            var data = await _extractionService.ReadDataAsync();
            return Ok(data);
        }

        [HttpGet("generate-file")]
        public async Task<IActionResult> GenerateFile()
        {
            var filePath = await _extractionService.GenerateFileAsync();
            return Ok(new { filePath });
        }
    }
}
