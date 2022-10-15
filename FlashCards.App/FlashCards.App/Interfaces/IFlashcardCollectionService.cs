using FlashCards.App.Models.Flashcards;
using FlashCards.App.ViewModels.Flashcards;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IFlashcardCollectionService
    {
        Task<FlashcardCollection> GetByID(int flashcardCollectionID);
        Task<IEnumerable<FlashcardCollection>> GetAllFlashcards();
        Task<IEnumerable<FlashcardCollection>> GetFlashcardsByUser(int userID);
        Task<IEnumerable<FlashcardCollection>> GetFlashcardsByCategory(int categoryID);
        Task<IEnumerable<FlashcardCollectionAvailable>> GetAvailablesByFlashcardCollectiion(int flashcardCollectionID);

        Task<int> CreateFlashcardCollection(CreateOrEditFlashcardViewModel data);
        Task EditFlashcardCollection(CreateOrEditFlashcardViewModel data);
        Task DeleteFlashcardCollection(int flashcardCollectionID);

        Task<int> AddFlashcardItem(CreateOrEditFlashcardItemViewModel data);
        Task EditFlashcardItem(CreateOrEditFlashcardItemViewModel data);
        Task DeletelashcardItem(DeleteFlashcardItemDto data);

        Task SendAvailable(CreateFlashcardAvailableViewModel data);
    }
}
