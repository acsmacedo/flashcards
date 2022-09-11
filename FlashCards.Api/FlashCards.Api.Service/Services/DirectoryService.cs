using FlashCards.Api.Core.Directories;
using FlashCards.Api.Service.DTO.Directories;

namespace FlashCards.Api.Service.Services;

public class DirectoryService : IDirectoryService
{
    private readonly ApplicationDbContext _context;

    public DirectoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DirectoryDto>> GetByUserIDAsync(int userID)
    {
        var directories = await _context.Directories
            .Where(x => x.UserID == userID)
            .ToListAsync();

        var result = directories.Select(x => new DirectoryDto(x));

        return result;
    }

    public async Task CreateAsync(CreateDirectoryDto data)
    {
        var entity = new UserDirectory(data.ParentID, data.UserID, data.Name);

        _context.Add(entity);

        await SaveChangesAsync();
    }

    public async Task EditAsync(EditDirectoryDto data)
    {
        var entity = GetByID(data.ID);

        entity.Edit(data.Name);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task DeleteAsync(DeleteDirectoryDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    private UserDirectory GetByID(int id)
    {
        var entity = _context.Directories
            .FirstOrDefault(x => x.UserDirectoryID == id);

        if (entity != null)
            return entity;

        throw new Exception("Diretório não encontrado.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
