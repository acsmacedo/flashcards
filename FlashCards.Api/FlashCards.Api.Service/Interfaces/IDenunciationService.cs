using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Service.Interfaces;

public interface IDenunciationService
{
    Task<IEnumerable<DenunciationDto>> GetAllAsync();
    Task<DenunciationDto> GetByIDAsync(int id);
    Task<int> CreateAsync(CreateDenunciationDto data);
    Task DeleteAsync(DeleteDenunciationDto data);
}
