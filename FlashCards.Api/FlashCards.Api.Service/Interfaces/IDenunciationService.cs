using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Service.Interfaces;

public interface IDenunciationService
{
    Task<IEnumerable<DenunciationDto>> GetAllAsync();
    Task CreateAsync(CreateDenunciationDto data);
}
