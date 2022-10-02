using FlashCards.Api.Service.DTO.NotificationSettings;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationSettingsController : ControllerBase
{
    private readonly INotificationSettingService _service;

    public NotificationSettingsController(INotificationSettingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpGet]
    [Route("User/{userID}")]
    public async Task<IActionResult> GetAllByUserIDAsync(int userID)
    {
        var result = await _service.GetAllByUserAsync(userID);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateNotificationSettingDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditNotificationSettingDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{notificationSettingID}")]
    public async Task<IActionResult> DeleteAsync(int notificationSettingID)
    {
        await _service.DeleteAsync(new DeleteNotificationSettingDto(notificationSettingID));

        return Ok();
    }
}
