using Microsoft.AspNetCore.Mvc;
using Trasnlator.Interfaces;

namespace Trasnlator.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class TranslationController(ITranslationService translationService) : ControllerBase
    {
        private readonly ITranslationService _translationService = translationService;

    [HttpGet]
    public async Task<IActionResult> Translate(
    [FromQuery] string text,
    [FromQuery] string from,
    [FromQuery] string to)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return BadRequest("Text to translate is required");
        }

        var result = await _translationService.TranslateAsync(text, from, to);
        return Ok(new { Original = text, Translation = result });
    }
}