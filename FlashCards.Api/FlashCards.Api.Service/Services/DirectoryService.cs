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

    public async Task<DirectoryDto> GetByUserIDAsync(int userID, int? directoryID)
    {
        if (directoryID == null)
        {
            var entity = _context.Directories
                .Include(x => x.FlashCardCollections)
                .Include(x => x.Children)
                .FirstOrDefault(x => x.UserDirectoryParentID == null && x.UserID == userID);

            if (entity == null)
            {
                var newEntity = new UserDirectory(null, userID, "ROOT" + userID);

                _context.Add(newEntity);

                await SaveChangesAsync();

                return new DirectoryDto(newEntity);
            }
            else
            {
                return new DirectoryDto(entity);
            }
        }
        else
        {
            var entity = _context.Directories
                .Include(x => x.FlashCardCollections)
                .Include(x => x.Children)
                .FirstOrDefault(x => x.ID == directoryID);

            if (entity== null)
                throw new Exception("Diretório não encontrado.");

            return new DirectoryDto(entity);
        }  
    }

    public async Task<int> CreateAsync(CreateDirectoryDto data)
    {
        var entity = new UserDirectory(data.ParentID, data.UserID, data.Name);

        _context.Add(entity);

        await SaveChangesAsync();

        return entity.ID;
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
            .FirstOrDefault(x => x.ID == id);

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
