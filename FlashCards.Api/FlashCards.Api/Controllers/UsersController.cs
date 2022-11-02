using FlashCards.Api.Service.DTO.Users;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IDirectoryService _directoryService;

    public UsersController(IUserService userService, IDirectoryService directoryService)
    {
        _userService = userService;
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
    [Route("{userID}/Relationship/{relationshipID}")]
    public async Task<IActionResult> GetUserRelationshipByIDAsync(int userID, int relationshipID)
    {
        var result = await _userService.GetUserRelationshipByIDAsync(userID, relationshipID);

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
        await _userService.ChangeSubscriptionTypeAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("AddOrEditNotificationSetting")]
    public async Task<IActionResult> AddOrEditNotificationSettingAsync(AddOrEditNotificationSettingDto data)
    {
        await _userService.AddOrEditNotificationSettingAsync(data);

        return Ok();
    }

    [HttpPost]
    [Route("{userID}/Photo")]
    public async Task<IActionResult> UpdatePhotoAsync(int userID)
    {
        try
        {
            if (Request.Form.Files.Count <= 0)
                return BadRequest();

            var data = new UpdateUserPhotoDto(
                userID: userID, 
                file: Request.Form.Files, 
                baseUrl: $"{Request.Scheme}://{Request.Host}{Request.PathBase}");

            await _userService.UpdatePhotoAsync(data);

            return Ok();
        }
        catch
        {
            return new StatusCodeResult(500);
        }  
    }
}
