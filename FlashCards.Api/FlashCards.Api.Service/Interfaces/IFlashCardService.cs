using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.Interfaces;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardCollectionDto>> GetByUserIDAsync(int userID);
    Task<FlashCardCollectionDto> GetByIDAsync(int userID);

    Task<int> CreateAsync(CreateFlashCardCollectionDto data);
    Task EditAsync(EditFlashCardCollectioDto data);
    Task DeleteAsync(DeleteFlashCardCollectioDto data);

    Task<int> AddCardAsync(AddFlashCardItemDto data);
    Task EditCardAsync(EditFlashCardItemDto data);
    Task RemoveCardAsync(RemoveFlashCardItemDto data);

    Task AddRatingAsync(AddFlashCardRatingDto data);
}
