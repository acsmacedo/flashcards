using FlashCards.Api.Core.Categories;
using FlashCards.Api.Service.DTO.Categories;

namespace FlashCards.Api.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        var result = categories.Select(x => new CategoryDto(x));

        return result;
    }

    public Task<CategoryDto> GetByIDAsync(int categoryID)
    {
        var category = GetByID(categoryID);
        var result = new CategoryDto(category);

        return Task.FromResult(result);
    }

    public async Task CreateAsync(CreateCategoryDto data)
    {
        var entity = new Category(data.Name, data.Image);

        _context.Add(entity);

        await SaveChangesAsync();
    }

    public async Task EditAsync(EditCategoryDto data)
    {
        var entity = GetByID(data.ID);

        entity.Edit(data.Name, data.Image);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task DeleteAsync(DeleteCategoryDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    private Category GetByID(int id)
    {
        var entity = _context.Categories
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Categoria não encontrada.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
