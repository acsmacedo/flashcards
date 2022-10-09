using FlashCards.App.Models.Flashcards;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashCards.App.Interfaces
{
    public interface IFlashcardCollectionService
    {
        Task<IEnumerable<FlashcardCollection>> GetAllFlashcards();
        Task<IEnumerable<FlashcardCollection>> GetFlashcardsByCategory(int categoryID);
    }
}
