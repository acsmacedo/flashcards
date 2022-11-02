using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Service.Tests.Services;

public class DenunciationServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllDenunciations_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDenunciationService objectTesting = new DenunciationService(context);

        CreateDenunciationDto createDto = new(
            accuserID: DefaultUserID,
            suspectID: DefaultUserID,
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        int denunciationID = await objectTesting.CreateAsync(createDto);

        IEnumerable<DenunciationDto> denunciations = await objectTesting.GetAllAsync();

        Assert.NotEmpty(denunciations);

        await objectTesting.DeleteAsync(new DeleteDenunciationDto(denunciationID));
    }

    [Fact]
    public async Task OnGetDenunciationByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDenunciationService objectTesting = new DenunciationService(context);

        CreateDenunciationDto createDto = new(
            accuserID: DefaultUserID,
            suspectID: DefaultUserID,
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        int denunciationID = await objectTesting.CreateAsync(createDto);

        DenunciationDto denunciation = await objectTesting.GetByIDAsync(denunciationID);

        Assert.NotNull(denunciation);
        Assert.Equal(createDto.AccuserID, denunciation.AccuserID);
        Assert.Equal(createDto.SuspectID, denunciation.SuspectID);
        Assert.Equal(createDto.Title, denunciation.Title);
        Assert.Equal(createDto.Description, denunciation.Description);

        await objectTesting.DeleteAsync(new DeleteDenunciationDto(denunciationID));
    }

    [Fact]
    public async Task OnCreateDenunciation_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDenunciationService objectTesting = new DenunciationService(context);

        CreateDenunciationDto createDto = new(
            accuserID: DefaultUserID,
            suspectID: DefaultUserID,
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        int denunciationID = await objectTesting.CreateAsync(createDto);
        DenunciationDto newDenunciation = await objectTesting.GetByIDAsync(denunciationID);

        Assert.NotNull(newDenunciation);
        Assert.Equal(createDto.AccuserID, newDenunciation.AccuserID);
        Assert.Equal(createDto.SuspectID, newDenunciation.SuspectID);
        Assert.Equal(createDto.Title, newDenunciation.Title);
        Assert.Equal(createDto.Description, newDenunciation.Description);

        await objectTesting.DeleteAsync(new DeleteDenunciationDto(denunciationID));
    }

    [Fact]
    public async Task OnDeleteDenunciation_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDenunciationService objectTesting = new DenunciationService(context);

        CreateDenunciationDto createDto = new(
            accuserID: DefaultUserID,
            suspectID: DefaultUserID,
            title: _random.Next().ToString(),
            description: _random.Next().ToString());

        int denunciationID = await objectTesting.CreateAsync(createDto);
        DenunciationDto denunciation = await objectTesting.GetByIDAsync(denunciationID);

        Assert.NotNull(denunciation);

        await objectTesting.DeleteAsync(new DeleteDenunciationDto(denunciationID));

        Task action() => objectTesting.GetByIDAsync(denunciationID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Denúncia não encontrada.", result.Message);
    }
}
