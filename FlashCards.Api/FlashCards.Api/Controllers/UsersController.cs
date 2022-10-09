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
    [Route("{userID}")]
    public async Task<IActionResult> GetByIDAsync(int userID)
    {
        var result = await _service.GetByIDAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("All/{userID}")]
    public async Task<IActionResult> GetAllAsync(int userID)
    {
        var result = await _service.GetAllAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("Following/{userID}")]
    public async Task<IActionResult> GetFollowingAsync(int userID)
    {
        var result = await _service.GetFollowingAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("Followers/{userID}")]
    public async Task<IActionResult> GetFollowersAsync(int userID)
    {
        var result = await _service.GetFollowersAsync(userID);

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

    [HttpPut]
    [Route("ChangeSubscription")]
    public async Task<IActionResult> ChangeSubscriptionAsync(ChangeSubscriptionTypeDto data)
    {
        await _service.ChangeSubscriptionType(data);

        return Ok();
    }

    [HttpPut]
    [Route("AddOrEditNotificationSetting")]
    public async Task<IActionResult> AddOrEditNotificationSettingAsync(AddOrEditNotificationSettingDto data)
    {
        await _service.AddOrEditNotificationSetting(data);

        return Ok();
    }
}
