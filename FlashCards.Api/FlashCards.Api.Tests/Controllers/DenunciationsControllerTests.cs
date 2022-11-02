using FlashCards.Api.Core.Denunciations;
using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Tests.Controllers;

public class DenunciationsControllerTests
{
    private readonly DenunciationsController _objectTesting;
    private readonly Mock<IDenunciationService> _mockService;

    private static readonly Random _random = new();

    public DenunciationsControllerTests()
    {
        _mockService = new Mock<IDenunciationService>();
        _objectTesting = new DenunciationsController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllDenunciations_ShouldReturnOkResult()
    {
        IEnumerable<DenunciationDto> denunciations = GenerateDenunciations();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(denunciations);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(denunciations);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnCreateDenunciation_ShouldReturnOkResult()
    {
        CreateDenunciationDto createDto = new(
            accuserID: _random.Next(),
            suspectID: _random.Next(),
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        CreateDenunciationDto? resultDto = null;

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateDenunciationDto>()))
            .Callback((CreateDenunciationDto x) => resultDto = x);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateDenunciationDto>()), Times.Once);
    }

    private static IEnumerable<DenunciationDto> GenerateDenunciations(int count = 5)
    {
        List<DenunciationDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateDenunciation());
        }

        return result;
    }

    private static DenunciationDto GenerateDenunciation()
    {
        var denunciation = new Denunciation(
            accuserID: _random.Next(),
            suspectID: _random.Next(),
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        return new DenunciationDto(denunciation);
    }
}
