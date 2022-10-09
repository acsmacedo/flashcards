using FlashCards.App.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
