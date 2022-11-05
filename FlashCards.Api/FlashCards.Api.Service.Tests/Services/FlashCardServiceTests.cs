using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.Tests.Services;

public class FlashCardServiceTests
{
    private const int DefaultUserID = -1;
    private const int DefaultCategoryID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllFlashCards_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        IEnumerable<FlashCardCollectionDto> flashCards = await objectTesting.GetAllAsync();

        Assert.NotEmpty(flashCards);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnGetAllFlashCardsByCategoryID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        IEnumerable<FlashCardCollectionDto> flashCards = await objectTesting.GetByCategoryIDAsync(DefaultCategoryID);

        Assert.NotEmpty(flashCards);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnGetAllFlashCardsByUserID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        IEnumerable<FlashCardCollectionDto> flashCards = await objectTesting.GetByUserIDAsync(DefaultUserID);

        Assert.NotEmpty(flashCards);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnGetFlashCardCollectionByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        FlashCardCollectionDto newFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.NotNull(newFlashCard);
        Assert.Equal(DefaultCategoryID, newFlashCard.CategoryID);
        Assert.Equal(rootDirectory.ID, newFlashCard.UserDirectoryID);
        Assert.Equal(createDto.Name, newFlashCard.Name);
        Assert.Equal(createDto.Description, newFlashCard.Description);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnGetAllFlashCardRating_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        AddFlashCardRatingDto addRatingDto = new(
            flashCardCollectionID: flashCardCollectionID,
            evaluatorID: DefaultUserID,
            rating: _random.Next(),
            comment: _random.Next().ToString());

        int flashCardRatingID = await objectTesting.AddRatingAsync(addRatingDto);

        IEnumerable<FlashCardRatingDto> flashcardRatings = await objectTesting.GetCardRatingByIDAsync(flashCardCollectionID);

        Assert.NotEmpty(flashcardRatings);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnCreateFlashCardCollection_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);
        FlashCardCollectionDto newFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.NotNull(newFlashCard);
        Assert.Equal(DefaultCategoryID, newFlashCard.CategoryID);
        Assert.Equal(rootDirectory.ID, newFlashCard.UserDirectoryID);
        Assert.Equal(createDto.Name, newFlashCard.Name);
        Assert.Equal(createDto.Description, newFlashCard.Description);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnEditFlashCardCollection_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);
        FlashCardCollectionDto oldFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.NotNull(oldFlashCard);
        Assert.Equal(DefaultCategoryID, oldFlashCard.CategoryID);
        Assert.Equal(rootDirectory.ID, oldFlashCard.UserDirectoryID);
        Assert.Equal(createDto.Name, oldFlashCard.Name);
        Assert.Equal(createDto.Description, oldFlashCard.Description);

        EditFlashCardCollectioDto editDto = new(
            id: flashCardCollectionID,
            categoryID: DefaultCategoryID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        await objectTesting.EditAsync(editDto);
        FlashCardCollectionDto updatedFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.NotNull(updatedFlashCard);

        Assert.Equal(oldFlashCard.ID, updatedFlashCard.ID);
        Assert.NotEqual(oldFlashCard.Name, updatedFlashCard.Name);
        Assert.NotEqual(oldFlashCard.Description, updatedFlashCard.Description);

        Assert.Equal(editDto.Name, updatedFlashCard.Name);
        Assert.Equal(editDto.Description, updatedFlashCard.Description);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnDeleteFlashCardCollection_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);
        FlashCardCollectionDto oldFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.NotNull(oldFlashCard);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));

        Task action() => objectTesting.GetByIDAsync(flashCardCollectionID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Coleção de flash card não encontrada.", result.Message);
    }

    [Fact]
    public async Task OnAddFlashCardItem_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);
        FlashCardCollectionDto beforeFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Empty(beforeFlashCard.Items);

        AddFlashCardItemDto addCardDto = new(
            flashCardCollectionID: flashCardCollectionID,
            frontDescription: _random.Next().ToString(),
            verseDescription: _random.Next().ToString());

        int flashCardItemID = await objectTesting.AddCardAsync(addCardDto);

        FlashCardCollectionDto afterFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Single(afterFlashCard.Items);
        Assert.Equal(flashCardItemID, afterFlashCard.Items.Single().FlashCardItemID);
        Assert.Equal(addCardDto.VerseDescription, afterFlashCard.Items.Single().VerseDescription);
        Assert.Equal(addCardDto.FrontDescription, afterFlashCard.Items.Single().FrontDescription);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnEditFlashCardItem_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        AddFlashCardItemDto addCardDto = new(
            flashCardCollectionID: flashCardCollectionID,
            frontDescription: _random.Next().ToString(),
            verseDescription: _random.Next().ToString());

        int flashCardItemID = await objectTesting.AddCardAsync(addCardDto);

        FlashCardCollectionDto beforeFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Single(beforeFlashCard.Items);
        Assert.Equal(addCardDto.VerseDescription, beforeFlashCard.Items.Single().VerseDescription);
        Assert.Equal(addCardDto.FrontDescription, beforeFlashCard.Items.Single().FrontDescription);

        EditFlashCardItemDto editCardDto = new(
            flashCardCollectionID: flashCardCollectionID,
            flashCardItemID: flashCardItemID,
            frontDescription: _random.Next().ToString(),
            verseDescription: _random.Next().ToString());

        await objectTesting.EditCardAsync(editCardDto);

        FlashCardCollectionDto afterFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Single(beforeFlashCard.Items);
        Assert.Equal(editCardDto.VerseDescription, beforeFlashCard.Items.Single().VerseDescription);
        Assert.Equal(editCardDto.FrontDescription, beforeFlashCard.Items.Single().FrontDescription);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnDeleteFlashCardItem_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);

        AddFlashCardItemDto addCardDto = new(
                    flashCardCollectionID: flashCardCollectionID,
                    frontDescription: _random.Next().ToString(),
                    verseDescription: _random.Next().ToString());

        int flashCardItemID = await objectTesting.AddCardAsync(addCardDto);

        FlashCardCollectionDto beforeFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Single(beforeFlashCard.Items);
        Assert.Equal(addCardDto.VerseDescription, beforeFlashCard.Items.Single().VerseDescription);
        Assert.Equal(addCardDto.FrontDescription, beforeFlashCard.Items.Single().FrontDescription);

        RemoveFlashCardItemDto removeBenefitDto = new(
            flashCardCollectionID: flashCardCollectionID,
            flashCardItemID: flashCardItemID);

        await objectTesting.RemoveCardAsync(removeBenefitDto);

        FlashCardCollectionDto afterFlashCard = await objectTesting.GetByIDAsync(flashCardCollectionID);

        Assert.Empty(beforeFlashCard.Items);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }

    [Fact]
    public async Task OnAddFlashCardRating_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IFlashCardService objectTesting = new FlashCardService(context);
        IDirectoryService directoryService = new DirectoryService(context);

        var rootDirectory = await directoryService.GetByUserIDAsync(DefaultUserID, null);

        CreateFlashCardCollectionDto createDto = new(
            categoryID: DefaultCategoryID,
            userDirectoryID: rootDirectory.ID,
            name: _random.Next().ToString(),
            description: _random.Next().ToString(),
            tags: Enumerable.Empty<string>());

        int flashCardCollectionID = await objectTesting.CreateAsync(createDto);
        IEnumerable<FlashCardRatingDto> beforeFlashcardRatings = await objectTesting.GetCardRatingByIDAsync(flashCardCollectionID);

        Assert.Empty(beforeFlashcardRatings);

        AddFlashCardRatingDto addRatingDto = new(
            flashCardCollectionID: flashCardCollectionID,
            evaluatorID: DefaultUserID,
            rating: _random.Next(),
            comment: _random.Next().ToString());

        int flashCardRatingID = await objectTesting.AddRatingAsync(addRatingDto);

        IEnumerable<FlashCardRatingDto> afterFlashcardRatings = await objectTesting.GetCardRatingByIDAsync(flashCardCollectionID);

        Assert.Single(afterFlashcardRatings);
        Assert.Equal(flashCardRatingID, afterFlashcardRatings.Single().ID);
        Assert.Equal(addRatingDto.Rating, afterFlashcardRatings.Single().Stars);
        Assert.Equal(addRatingDto.Comment, afterFlashcardRatings.Single().Comment);

        await objectTesting.DeleteAsync(new DeleteFlashCardCollectioDto(flashCardCollectionID));
    }
}
