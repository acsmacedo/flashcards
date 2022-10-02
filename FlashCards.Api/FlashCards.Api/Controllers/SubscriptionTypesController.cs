using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionTypesController : ControllerBase
{
    private readonly ISubscriptionTypeService _service;

    public SubscriptionTypesController(ISubscriptionTypeService service)
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
    public async Task<IActionResult> CreateAsync(CreateSubscriptionTypeDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditSubscriptionTypeDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{subscriptionTypeID}")]
    public async Task<IActionResult> DeleteAsync(int subscriptionTypeID)
    {
        await _service.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));

        return Ok();
    }

    [HttpPost]
    [Route("Benefit")]
    public async Task<IActionResult> AddBenefitAsync(AddSubscriptionTypeBenefitDto data)
    {
        await _service.AddBenefitAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("Benefit")]
    public async Task<IActionResult> EditBenefitAsync(EditSubscriptionTypeBenefitDto data)
    {
        await _service.EditBenefitAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{subscriptionTypeID}/Benefit/{subscriptionTypeBenefitID}")]
    public async Task<IActionResult> RemoveBenefitAsync(int subscriptionTypeID, int subscriptionTypeBenefitID)
    {
        var data = new RemoveSubscriptionTypeBenefitDto(
            subscriptionTypeID: subscriptionTypeID, 
            subscriptionTypeBenefitID: subscriptionTypeBenefitID);

        await _service.RemoveBenefitAsync(data);

        return Ok();
    }
}
