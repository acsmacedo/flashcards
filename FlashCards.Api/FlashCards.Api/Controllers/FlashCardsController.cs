namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashCardsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
