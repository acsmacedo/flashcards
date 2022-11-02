using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Tests.Controllers;

public class FlashCardsControllerTests
{
    private readonly FlashCardsController _objectTesting;
    private readonly Mock<IFlashCardService> _mockService;

    private static readonly Random _random = new();

    public FlashCardsControllerTests()
    {
        _mockService = new Mock<IFlashCardService>();
        _objectTesting = new FlashCardsController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllFlashCards_ShouldReturnOkResult()
    {
        IEnumerable<FlashCardCollectionDto> flashCards = GenerateFlashCards();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(flashCards);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(flashCards);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnGetAllFlashCardsByUserID_ShouldReturnOkResult()
    {
        IEnumerable<FlashCardCollectionDto> flashCards = GenerateFlashCards();
        int userID = _random.Next();

        _mockService.Setup(x => x.GetByUserIDAsync(userID)).ReturnsAsync(flashCards);

        IActionResult response = await _objectTesting.GetByUserIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(flashCards);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetByUserIDAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnGetAllFlashCardsByCategoryID_ShouldReturnOkResult()
    {
        IEnumerable<FlashCardCollectionDto> flashCards = GenerateFlashCards();
        int categoryID = _random.Next();

        _mockService.Setup(x => x.GetByCategoryIDAsync(categoryID)).ReturnsAsync(flashCards);

        IActionResult response = await _objectTesting.GetByCategoryIDAsync(categoryID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(flashCards);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetByCategoryIDAsync(categoryID), Times.Once);
    }

    [Fact]
    public async Task OnGetFlashCardByID_ShouldReturnOkResult()
    {
        FlashCardCollectionDto flashCard = GenerateFlashCard();
        int flashcardID = _random.Next();

        _mockService.Setup(x => x.GetByIDAsync(flashcardID)).ReturnsAsync(flashCard);

        IActionResult response = await _objectTesting.GetByIDAsync(flashcardID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(flashCard);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetByIDAsync(flashcardID), Times.Once);
    }

    [Fact]
    public async Task OnGetAllFlashCardRatingsByCollectionID_ShouldReturnOkResult()
    {
        IEnumerable<FlashCardRatingDto> flashCards = GenerateFlashCardRatings();
        int flashcardID = _random.Next();

        _mockService.Setup(x => x.GetCardRatingByIDAsync(flashcardID)).ReturnsAsync(flashCards);

        IActionResult response = await _objectTesting.GetCardRatingByIDAsync(flashcardID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(flashCards);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetCardRatingByIDAsync(flashcardID), Times.Once);
    }

    [Fact]
    public async Task OnCreateFlashCard_ShouldReturnOkResult()
    {
        CreateFlashCardCollectionDto createDto = new(
            categoryID: _random.Next(),
            userDirectoryID: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        CreateFlashCardCollectionDto? resultDto = null;
        int flashCardCollectionID = _random.Next();

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateFlashCardCollectionDto>()))
            .Callback((CreateFlashCardCollectionDto x) => resultDto = x)
            .ReturnsAsync(flashCardCollectionID);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);
        Assert.Equal(flashCardCollectionID, objectResponse.Value);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateFlashCardCollectionDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditFlashCard_ShouldReturnOkResult()
    {
        EditFlashCardCollectioDto editDto = new(
            id: _random.Next(),
            categoryID: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        EditFlashCardCollectioDto? resultDto = null;

        _mockService
            .Setup(x => x.EditAsync(It.IsAny<EditFlashCardCollectioDto>()))
            .Callback((EditFlashCardCollectioDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditAsync(It.IsAny<EditFlashCardCollectioDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteFlashCard_ShouldReturnOkResult()
    {
        DeleteFlashCardCollectioDto deleteDto = new(_random.Next());
        DeleteFlashCardCollectioDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteFlashCardCollectioDto>()))
            .Callback((DeleteFlashCardCollectioDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteFlashCardCollectioDto>()), Times.Once);
    }

    [Fact]
    public async Task OnAddFlashCardItem_ShouldReturnOkResult()
    {
        AddFlashCardItemDto addCardDto = new(
            flashCardCollectionID: _random.Next(),
            verseDescription: _random.Next().ToString(),
            frontDescription: _random.Next().ToString());

        AddFlashCardItemDto? resultDto = null;
        int flashCardItemExpected = _random.Next();

        _mockService
            .Setup(x => x.AddCardAsync(It.IsAny<AddFlashCardItemDto>()))
            .Callback((AddFlashCardItemDto x) => resultDto = x)
            .ReturnsAsync(flashCardItemExpected);

        IActionResult response = await _objectTesting.AddCardAsync(addCardDto);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(addCardDto);

        Assert.Equal(expectedData, resultData);
        Assert.Equal(flashCardItemExpected, objectResponse.Value);

        _mockService.Verify(x => x.AddCardAsync(It.IsAny<AddFlashCardItemDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditFlashCardItem_ShouldReturnOkResult()
    {
        EditFlashCardItemDto editCardDto = new(
            flashCardCollectionID: _random.Next(),
            flashCardItemID: _random.Next(),
            verseDescription: _random.Next().ToString(),
            frontDescription: _random.Next().ToString());

        EditFlashCardItemDto? resultDto = null;

        _mockService
            .Setup(x => x.EditCardAsync(It.IsAny<EditFlashCardItemDto>()))
            .Callback((EditFlashCardItemDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditCardAsync(editCardDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editCardDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditCardAsync(It.IsAny<EditFlashCardItemDto>()), Times.Once);
    }

    [Fact]
    public async Task OnRemoveFlashCardItem_ShouldReturnOkResult()
    {
        RemoveFlashCardItemDto deleteCardDto = new(
            flashCardCollectionID: _random.Next(),
            flashCardItemID: _random.Next());

        RemoveFlashCardItemDto? resultDto = null;

        _mockService
            .Setup(x => x.RemoveCardAsync(It.IsAny<RemoveFlashCardItemDto>()))
            .Callback((RemoveFlashCardItemDto x) => resultDto = x);

        IActionResult response = await _objectTesting.RemoveCardAsync(
            flashCardCollectionID: deleteCardDto.FlashCardCollectionID,
            flashCardItemID: deleteCardDto.FlashCardItemID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteCardDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.RemoveCardAsync(It.IsAny<RemoveFlashCardItemDto>()), Times.Once);
    }

    [Fact]
    public async Task OnAddFlashCardRating_ShouldReturnOkResult()
    {
        AddFlashCardRatingDto addRatingDto = new(
            flashCardCollectionID: _random.Next(),
            evaluatorID: _random.Next(),
            rating: _random.Next(),
            comment: _random.Next().ToString());

        AddFlashCardRatingDto? resultDto = null;

        _mockService
            .Setup(x => x.AddRatingAsync(It.IsAny<AddFlashCardRatingDto>()))
            .Callback((AddFlashCardRatingDto x) => resultDto = x);

        IActionResult response = await _objectTesting.AddRatingAsync(addRatingDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(addRatingDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.AddRatingAsync(It.IsAny<AddFlashCardRatingDto>()), Times.Once);
    }

    private static IEnumerable<FlashCardCollectionDto> GenerateFlashCards(int count = 5)
    {
        List<FlashCardCollectionDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateFlashCard());
        }

        return result;
    }

    private static FlashCardCollectionDto GenerateFlashCard()
    {
        var flashCard = new FlashCardCollection(
            categoryID: _random.Next(),
            userDirectoryID: _random.Next(),
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        return new FlashCardCollectionDto(flashCard);
    }

    private static IEnumerable<FlashCardRatingDto> GenerateFlashCardRatings(int count = 5)
    {
        List<FlashCardRatingDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateFlashCardRating());
        }

        return result;
    }

    private static FlashCardRatingDto GenerateFlashCardRating()
    {
        var flashCard = new FlashCardRating(
            userID: _random.Next(),
            rating: _random.Next(),
            comment: _random.Next().ToString());

        return new FlashCardRatingDto(flashCard);
    }
}
