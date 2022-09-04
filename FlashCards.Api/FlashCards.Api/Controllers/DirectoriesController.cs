namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectoriesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
