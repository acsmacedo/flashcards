using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.Interfaces;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardCollectionDto>> GetByUserIDAsync(int userID);
    Task CreateAsync(CreateFlashCardCollectionDto data);
    Task EditAsync(EditFlashCardCollectioDto data);
    Task DeleteAsync(DeleteFlashCardCollectioDto data);

    Task AddCardAsync(AddFlashCardItemDto data);
    Task EditCardAsync(EditFlashCardItemDto data);
    Task RemoveCardAsync(RemoveFlashCardItemDto data);

    Task AddRatingAsync(AddFlashCardRatingDto data);
}
