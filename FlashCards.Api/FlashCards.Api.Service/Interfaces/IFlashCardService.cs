using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.Interfaces;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardCollectionDto>> GetAllAsync();
    Task<IEnumerable<FlashCardCollectionDto>> GetByCategoryIDAsync(int categoryID);
    Task<IEnumerable<FlashCardCollectionDto>> GetByUserIDAsync(int userID);
    Task<FlashCardCollectionDto> GetByIDAsync(int flashcardCollectionID);

    Task<int> CreateAsync(CreateFlashCardCollectionDto data);
    Task EditAsync(EditFlashCardCollectioDto data);
    Task DeleteAsync(DeleteFlashCardCollectioDto data);

    Task<int> AddCardAsync(AddFlashCardItemDto data);
    Task EditCardAsync(EditFlashCardItemDto data);
    Task RemoveCardAsync(RemoveFlashCardItemDto data);

    Task<IEnumerable<FlashCardRatingDto>> GetCardRatingByIDAsync(int flashcardCollectionID);
    Task<int> AddRatingAsync(AddFlashCardRatingDto data);
}
