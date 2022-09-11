using FlashCards.Api.Service.DTO.Categories;

namespace FlashCards.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _service.GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryDto data)
    {
        await _service.CreateAsync(data);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditAsync(EditCategoryDto data)
    {
        await _service.EditAsync(data);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(DeleteCategoryDto data)
    {
        await _service.DeleteAsync(data);

        return Ok();
    }
}
