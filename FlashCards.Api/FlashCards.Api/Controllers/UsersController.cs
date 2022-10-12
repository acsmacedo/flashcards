using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IDirectoryService _directoryService;

    public UsersController(IUserService service, IDirectoryService directoryService)
    {
        _userService = service;
        _directoryService = directoryService;
    }

    [HttpGet]
    [Route("{userID}")]
    public async Task<IActionResult> GetByIDAsync(int userID)
    {
        var result = await _userService.GetByIDAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("{userID}/Directories")]
    public async Task<IActionResult> GetDirectoryByUserIDAsync(int userID)
    {
        var result = await _directoryService.GetByUserIDAsync(userID, null);

        return Ok(result);
    }

    [HttpGet]
    [Route("{userID}/Directories/{directoryID}")]
    public async Task<IActionResult> GetDirectoryByUserIDAsync(int userID, int? directoryID)
    {
        var result = await _directoryService.GetByUserIDAsync(userID, directoryID);

        return Ok(result);
    }

    [HttpGet]
    [Route("All/{userID}")]
    public async Task<IActionResult> GetAllAsync(int userID)
    {
        var result = await _userService.GetAllAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("Following/{userID}")]
    public async Task<IActionResult> GetFollowingAsync(int userID)
    {
        var result = await _userService.GetFollowingAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("Followers/{userID}")]
    public async Task<IActionResult> GetFollowersAsync(int userID)
    {
        var result = await _userService.GetFollowersAsync(userID);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditUserDto data)
    {
        await _userService.EditAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("Follow")]
    public async Task<IActionResult> FollowAsync(FollowDto data)
    {
        await _userService.FollowAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("Unfollow")]
    public async Task<IActionResult> UnfollowAsync(UnfollowDto data)
    {
        await _userService.UnfollowAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("EditNotificationFollowed")]
    public async Task<IActionResult> EditNotificationFollowedAsync(FollowNotificationDto data)
    {
        await _userService.EditNotificationFollowedAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("ChangeSubscription")]
    public async Task<IActionResult> ChangeSubscriptionAsync(ChangeSubscriptionTypeDto data)
    {
        await _userService.ChangeSubscriptionType(data);

        return Ok();
    }

    [HttpPut]
    [Route("AddOrEditNotificationSetting")]
    public async Task<IActionResult> AddOrEditNotificationSettingAsync(AddOrEditNotificationSettingDto data)
    {
        await _userService.AddOrEditNotificationSetting(data);

        return Ok();
    }
}
