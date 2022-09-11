using FlashCards.Api.Service.DTO.Notifications;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationsController(INotificationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByUserIDAsync(int userID)
    {
        var result = await _service.GetAllByUserIDAsync(userID);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateNotificationDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> ReadAsync(ReadNotificationDto data)
    {
        await _service.ReadAsync(data);

        return Ok();
    }
}
