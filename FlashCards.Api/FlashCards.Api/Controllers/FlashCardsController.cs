using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashCardsController : ControllerBase
{
    private readonly IFlashCardService _service;

    public FlashCardsController(IFlashCardService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByUserIDAsync(int userID)
    {
        var result = await _service.GetByUserIDAsync(userID);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateFlashCardCollectionDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditFlashCardCollectioDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(DeleteFlashCardCollectioDto data)
    {
        await _service.DeleteAsync(data);

        return Ok();
    }

    [HttpPost]
    [Route("CardItem")]
    public async Task<IActionResult> AddCardAsync(AddFlashCardItemDto data)
    {
        await _service.AddCardAsync(data);

        return Ok();
    }

    [HttpPut]
    [Route("CardItem")]
    public async Task<IActionResult> EditCardAsync(EditFlashCardItemDto data)
    {
        await _service.EditCardAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("CardItem")]
    public async Task<IActionResult> RemoveCardAsync(RemoveFlashCardItemDto data)
    {
        await _service.RemoveCardAsync(data);

        return Ok();
    }

    [HttpPost]
    [Route("CardRating")]
    public async Task<IActionResult> AddRatingAsync(AddFlashCardRatingDto data)
    {
        await _service.AddRatingAsync(data);

        return Ok();
    }
}
