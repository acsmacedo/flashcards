using FlashCards.Api.Service.DTO.Directories;

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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDirectoryDto data)
    {
        var result = await _service.CreateAsync(data);

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditDirectoryDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    [Route("{userDirectoryID}")]
    public async Task<IActionResult> DeleteAsync(int userDirectoryID)
    {
        await _service.DeleteAsync(new DeleteDirectoryDto(userDirectoryID));

        return Ok();
    }
}
