﻿using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryService _service;

    public DirectoriesController(IDirectoryService service)
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
    public async Task<IActionResult> CreateAsync(CreateDirectoryDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditDirectoryDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(DeleteDirectoryDto data)
    {
        await _service.DeleteAsync(data);

        return Ok();
    }
}
