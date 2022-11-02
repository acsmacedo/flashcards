using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Service.Tests.Services;

public class DirectoryServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetDirectoryByUserID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDirectoryService objectTesting = new DirectoryService(context);

        DirectoryDto rootDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, null);

        CreateDirectoryDto createDto = new(
            parentID: rootDirectory.ID,
            userID: DefaultUserID,
            name: _random.Next().ToString());

        int directoryID = await objectTesting.CreateAsync(createDto);

        DirectoryDto directory = await objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);

        Assert.NotNull(directory);
        Assert.Equal(createDto.ParentID, directory.ParentID);
        Assert.Equal(createDto.UserID, directory.UserID);
        Assert.Equal(createDto.Name, directory.Name);

        await objectTesting.DeleteAsync(new DeleteDirectoryDto(directoryID));
    }

    [Fact]
    public async Task OnCreateDirectory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDirectoryService objectTesting = new DirectoryService(context);

        DirectoryDto rootDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, null);

        CreateDirectoryDto createDto = new(
            parentID: rootDirectory.ID,
            userID: DefaultUserID,
            name: _random.Next().ToString());

        int directoryID = await objectTesting.CreateAsync(createDto);
        
        DirectoryDto directory = await objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);

        Assert.NotNull(directory);
        Assert.Equal(createDto.ParentID, directory.ParentID);
        Assert.Equal(createDto.UserID, directory.UserID);
        Assert.Equal(createDto.Name, directory.Name);

        await objectTesting.DeleteAsync(new DeleteDirectoryDto(directoryID));
    }

    [Fact]
    public async Task OnEditDirectory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDirectoryService objectTesting = new DirectoryService(context);
        
        DirectoryDto rootDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, null);

        CreateDirectoryDto createDto = new(
            parentID: rootDirectory.ID,
            userID: DefaultUserID,
            name: _random.Next().ToString());

        int directoryID = await objectTesting.CreateAsync(createDto);
        DirectoryDto oldDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);

        Assert.Equal(createDto.ParentID, oldDirectory.ParentID);
        Assert.Equal(createDto.UserID, oldDirectory.UserID);
        Assert.Equal(createDto.Name, oldDirectory.Name);

        EditDirectoryDto editDto = new(
            id: oldDirectory.ID,
            name: _random.Next().ToString());

        await objectTesting.EditAsync(editDto);
        DirectoryDto updatedDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);

        Assert.NotNull(updatedDirectory);

        Assert.Equal(oldDirectory.ID, updatedDirectory.ID);
        Assert.NotEqual(oldDirectory.Name, updatedDirectory.Name);

        Assert.Equal(editDto.Name, updatedDirectory.Name);

        await objectTesting.DeleteAsync(new DeleteDirectoryDto(directoryID));
    }

    [Fact]
    public async Task OnDeleteDirectory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        IDirectoryService objectTesting = new DirectoryService(context);

        DirectoryDto rootDirectory = await objectTesting.GetByUserIDAsync(DefaultUserID, null);

        CreateDirectoryDto createDto = new(
            parentID: rootDirectory.ID,
            userID: DefaultUserID,
            name: _random.Next().ToString());

        int directoryID = await objectTesting.CreateAsync(createDto);
        DirectoryDto directory = await objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);

        Assert.NotNull(directory);

        await objectTesting.DeleteAsync(new DeleteDirectoryDto(directoryID));

        Task action() => objectTesting.GetByUserIDAsync(DefaultUserID, directoryID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Diretório não encontrado.", result.Message);
    }
}
