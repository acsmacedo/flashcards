using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DenunciationsController : ControllerBase
{
    private readonly IDenunciationService _service;

    public DenunciationsController(IDenunciationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDenunciationDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }
}
