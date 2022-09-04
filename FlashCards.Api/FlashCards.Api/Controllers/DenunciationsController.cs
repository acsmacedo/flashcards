namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DenunciationsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
