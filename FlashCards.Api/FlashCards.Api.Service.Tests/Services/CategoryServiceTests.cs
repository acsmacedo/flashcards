using FlashCards.Api.Service.DTO.Categories;

namespace FlashCards.Api.Service.Tests.Services;

public class CategoryServiceTests
{
    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllCategories_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ICategoryService objectTesting = new CategoryService(context);

        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        int categoryID = await objectTesting.CreateAsync(createDto);

        IEnumerable<CategoryDto> categories = await objectTesting.GetAllAsync();

        Assert.NotEmpty(categories);

        await objectTesting.DeleteAsync(new DeleteCategoryDto(categoryID));
    }

    [Fact]
    public async Task OnGetCategoriesByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ICategoryService objectTesting = new CategoryService(context);

        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        int categoryID = await objectTesting.CreateAsync(createDto);

        CategoryDto category = await objectTesting.GetByIDAsync(categoryID);

        Assert.NotNull(category);
        Assert.Equal(createDto.Name, category.Name);
        Assert.Equal(createDto.Image, category.Image);

        await objectTesting.DeleteAsync(new DeleteCategoryDto(categoryID));
    }

    [Fact]
    public async Task OnCreateCategory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ICategoryService objectTesting = new CategoryService(context);

        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        int categoryID = await objectTesting.CreateAsync(createDto);
        CategoryDto newCategory = await objectTesting.GetByIDAsync(categoryID);

        Assert.NotNull(newCategory);
        Assert.Equal(createDto.Name, newCategory.Name);
        Assert.Equal(createDto.Image, newCategory.Image);

        await objectTesting.DeleteAsync(new DeleteCategoryDto(categoryID));
    }

    [Fact]
    public async Task OnEditCategory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ICategoryService objectTesting = new CategoryService(context);

        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        int categoryID = await objectTesting.CreateAsync(createDto);
        CategoryDto oldCategory = await objectTesting.GetByIDAsync(categoryID);

        Assert.NotNull(oldCategory);
        Assert.Equal(createDto.Name, oldCategory.Name);
        Assert.Equal(createDto.Image, oldCategory.Image);

        EditCategoryDto editDto = new(
            id: oldCategory.ID,
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        await objectTesting.EditAsync(editDto);
        CategoryDto updatedCategory = await objectTesting.GetByIDAsync(categoryID);

        Assert.NotNull(updatedCategory);

        Assert.Equal(oldCategory.ID, updatedCategory.ID);
        Assert.NotEqual(oldCategory.Name, updatedCategory.Name);
        Assert.NotEqual(oldCategory.Image, updatedCategory.Image);

        Assert.Equal(editDto.Name, updatedCategory.Name);
        Assert.Equal(editDto.Image, updatedCategory.Image);

        await objectTesting.DeleteAsync(new DeleteCategoryDto(categoryID));
    }

    [Fact]
    public async Task OnDeleteCategory_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ICategoryService objectTesting = new CategoryService(context);

        CreateCategoryDto createDto = new(
            name: _random.Next().ToString(),
            image: _random.Next().ToString());

        int categoryID = await objectTesting.CreateAsync(createDto);
        CategoryDto category = await objectTesting.GetByIDAsync(categoryID);

        Assert.NotNull(category);

        await objectTesting.DeleteAsync(new DeleteCategoryDto(categoryID));

        Task action() => objectTesting.GetByIDAsync(categoryID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Categoria não encontrada.", result.Message);
    }
}
