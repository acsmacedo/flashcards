using FlashCards.Api.Core.Denunciations;
using FlashCards.Api.Service.DTO.Denunciations;

namespace FlashCards.Api.Service.Services;

public class DenunciationService : IDenunciationService
{
    private readonly ApplicationDbContext _context;

    public DenunciationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateDenunciationDto data)
    {
        var entity = new Denunciation(
            accuserID: data.AccuserID,
            suspectID: data.SuspectID,
            title: data.Title,
            description: data.Description);

        _context.Add(entity);

        await SaveChangesAsync();
    }

    public async Task<IEnumerable<DenunciationDto>> GetAllAsync()
    {
        var categories = await _context.Denunciations.ToListAsync();
        var result = categories.Select(x => new DenunciationDto(x));

        return result;
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
