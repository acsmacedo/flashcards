﻿using FlashCards.Api.Service.DTO.FlashCards;

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
    [Route("Users/{userID}")]
    public async Task<IActionResult> GetByUserIDAsync(int userID)
    {
        var result = await _service.GetByUserIDAsync(userID);

        return Ok(result);
    }

    [HttpGet]
    [Route("{flashcardCollectionID}")]
    public async Task<IActionResult> GetByIDAsync(int flashcardCollectionID)
    {
        var result = await _service.GetByIDAsync(flashcardCollectionID);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateFlashCardCollectionDto data)
    {
        var id = await _service.CreateAsync(data);

        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditFlashCardCollectioDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{flashCardCollectionID}")]
    public async Task<IActionResult> DeleteAsync(int flashCardCollectionID)
    {
        await _service.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));

        return Ok();
    }

    [HttpPost]
    [Route("CardItem")]
    public async Task<IActionResult> AddCardAsync(AddFlashCardItemDto data)
    {
        var id = await _service.AddCardAsync(data);

        return Ok(id);
    }

    [HttpPut]
    [Route("CardItem")]
    public async Task<IActionResult> EditCardAsync(EditFlashCardItemDto data)
    {
        await _service.EditCardAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{flashCardCollectionID}/CardItem/{flashCardItemID}")]
    public async Task<IActionResult> RemoveCardAsync(int flashCardCollectionID, int flashCardItemID)
    {
        var data = new RemoveFlashCardItemDto(
            flashCardCollectionID: flashCardCollectionID, 
            flashCardItemID: flashCardItemID);

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
