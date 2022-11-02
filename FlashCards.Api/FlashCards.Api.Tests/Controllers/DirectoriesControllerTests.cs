using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Tests.Controllers;

public class DirectoriesControllerTests
{
    private readonly DirectoriesController _objectTesting;
    private readonly Mock<IDirectoryService> _mockService;

    private static readonly Random _random = new();

    public DirectoriesControllerTests()
    {
        _mockService = new Mock<IDirectoryService>();
        _objectTesting = new DirectoriesController(_mockService.Object);
    }

    [Fact]
    public async Task OnCreateDirectory_ShouldReturnOkResult()
    {
        CreateDirectoryDto createDto = new(
            parentID: _random.Next(),
            userID: _random.Next(),
            name: _random.Next().ToString());

        CreateDirectoryDto? resultDto = null;
        int expectedDirectoryID = _random.Next();

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateDirectoryDto>()))
            .Callback((CreateDirectoryDto x) => resultDto = x)
            .ReturnsAsync(expectedDirectoryID);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);
        Assert.Equal(expectedDirectoryID, objectResponse.Value);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateDirectoryDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditDirectory_ShouldReturnOkResult()
    {
        EditDirectoryDto editDto = new(
            id: _random.Next(),
            name: _random.Next().ToString());

        EditDirectoryDto? resultDto = null;

        _mockService
            .Setup(x => x.EditAsync(It.IsAny<EditDirectoryDto>()))
            .Callback((EditDirectoryDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditAsync(It.IsAny<EditDirectoryDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteDirectory_ShouldReturnOkResult()
    {
        DeleteDirectoryDto deleteDto = new(_random.Next());
        DeleteDirectoryDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteDirectoryDto>()))
            .Callback((DeleteDirectoryDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteDirectoryDto>()), Times.Once);
    }
}
