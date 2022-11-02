using FlashCards.Api.Core.Categories;
using FlashCards.Api.Service.DTO.Categories;

namespace FlashCards.Api.Tests.Controllers;

public class CategoriesControllerTests
{
    private readonly CategoriesController _objectTesting;
    private readonly Mock<ICategoryService> _mockService;

    private static readonly Random _random = new();

    public CategoriesControllerTests()
    {
        _mockService = new Mock<ICategoryService>();
        _objectTesting = new CategoriesController(_mockService.Object);    
    }

    [Fact]
    public async Task OnGetAllCategories_ShouldReturnOkResult()
    {
        IEnumerable<CategoryDto> categories = GenerateCategories();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(categories);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnGetCategoryByID_ShouldReturnOkResult()
    {
        int categoryID = _random.Next();
        CategoryDto category = GenerateCategory();

        _mockService.Setup(x => x.GetByIDAsync(categoryID)).ReturnsAsync(category);

        IActionResult response = await _objectTesting.GetByIDAsync(categoryID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(category);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetByIDAsync(categoryID), Times.Once);
    }

    [Fact]
    public async Task OnCreateCategory_ShouldReturnOkResult()
    {
        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        CreateCategoryDto? resultDto = null;

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateCategoryDto>()))
            .Callback((CreateCategoryDto x) => resultDto = x);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateCategoryDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditCategory_ShouldReturnOkResult()
    {
        EditCategoryDto editDto = new(
            id: _random.Next(),
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        EditCategoryDto? resultDto = null;

        _mockService
            .Setup(x => x.EditAsync(It.IsAny<EditCategoryDto>()))
            .Callback((EditCategoryDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditAsync(It.IsAny<EditCategoryDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteCategory_ShouldReturnOkResult()
    {
        DeleteCategoryDto deleteDto = new(_random.Next());
        DeleteCategoryDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteCategoryDto>()))
            .Callback((DeleteCategoryDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteCategoryDto>()), Times.Once);
    }

    private static IEnumerable<CategoryDto> GenerateCategories(int count = 5)
    {
        List<CategoryDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateCategory());
        }

        return result;
    }

    private static CategoryDto GenerateCategory()
    {
        var category = new Category(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        return new CategoryDto(category);
    }
}
