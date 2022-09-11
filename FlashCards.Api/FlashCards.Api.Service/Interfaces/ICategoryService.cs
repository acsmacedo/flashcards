using FlashCards.Api.Service.DTO.Categories;

namespace FlashCards.Api.Service.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task CreateAsync(CreateCategoryDto data);
    Task EditAsync(EditCategoryDto data);
    Task DeleteAsync(DeleteCategoryDto data);
}
