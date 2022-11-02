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

    public async Task<IEnumerable<DenunciationDto>> GetAllAsync()
    {
        var denunciations = await _context.Denunciations.ToListAsync();
        var result = denunciations.Select(x => new DenunciationDto(x));

        return result;
    }

    public Task<DenunciationDto> GetByIDAsync(int categoryID)
    {
        var denunciation = GetByID(categoryID);
        var result = new DenunciationDto(denunciation);

        return Task.FromResult(result);
    }

    public async Task<int> CreateAsync(CreateDenunciationDto data)
    {
        var entity = new Denunciation(
            accuserID: data.AccuserID,
            suspectID: data.SuspectID,
            title: data.Title,
            description: data.Description);

        _context.Add(entity);

        await SaveChangesAsync();

        return entity.ID;
    }

    public async Task DeleteAsync(DeleteDenunciationDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    private Denunciation GetByID(int id)
    {
        var entity = _context.Denunciations
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Denúncia não encontrada.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
