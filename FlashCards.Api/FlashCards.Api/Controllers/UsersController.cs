using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByIDAsync(int id)
    {
        var result = await _service.GetByIDAsync(id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditUserDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("Follow")]
    public async Task<IActionResult> FollowAsync(FollowDto data)
    {
        await _service.FollowAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("Unfollow")]
    public async Task<IActionResult> UnfollowAsync(UnfollowDto data)
    {
        await _service.UnfollowAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("EditNotificationFollowed")]
    public async Task<IActionResult> EditNotificationFollowedAsync(FollowNotificationDto data)
    {
        await _service.EditNotificationFollowedAsync(data);

        return Ok();
    }
}
