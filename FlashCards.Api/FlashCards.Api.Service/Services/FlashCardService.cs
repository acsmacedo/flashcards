using FlashCards.Api.Core.FlashCards;
using FlashCards.Api.Service.DTO.FlashCards;

namespace FlashCards.Api.Service.Services;

public class FlashCardService : IFlashCardService
{
    private readonly ApplicationDbContext _context;

    public FlashCardService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddCardAsync(AddFlashCardItemDto data)
    {
        var entity = _context.FlashCards
            .Include(x => x.Cards)
            .FirstOrDefault(x => x.ID == data.FlashCardCollectionID);

        if (entity == null)
            throw new Exception("Coleção de flash card não encontrada.");

        entity.AddCardItem(
            frontDescription: data.FrontDescription, 
            verseDescription: data.VerseDescription);

        await SaveChangesAsync();

        return entity.Cards.First(x => x.FrontDescription == data.FrontDescription && x.VerseDescription == data.VerseDescription).FlashCardItemID;
    }

    public async Task AddRatingAsync(AddFlashCardRatingDto data)
    {
        var entity = _context.FlashCards
            .Include(x => x.Ratings)
            .FirstOrDefault(x => x.ID == data.FlashCardCollectionID);

        if (entity == null)
            throw new Exception("Coleção de flash card não encontrada.");

        entity.AddRating(
            userID: data.UserID,
            rating: data.Rating,
            comment: data.Comment);

        await SaveChangesAsync();
    }

    public async Task<int> CreateAsync(CreateFlashCardCollectionDto data)
    {
        var entity = new FlashCardCollection(
            categoryID: data.CategoryID,
            userDirectoryID: data.UserDirectoryID,
            name: data.Name,
            description: data.Description,
            tags: data.Tags);

        _context.Add(entity);

        await SaveChangesAsync();

        return entity.ID;
    }

    public async Task DeleteAsync(DeleteFlashCardCollectioDto data)
    {
        var entity = GetByID(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    public async Task EditAsync(EditFlashCardCollectioDto data)
    {
        var entity = GetByID(data.ID);

        entity.Edit(
            categoryID: data.CategoryID,
            name: data.Name,
            description: data.Description,
            tags: data.Tags);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public Task EditCardAsync(EditFlashCardItemDto data)
    {
        var entity = _context.FlashCards
            .Include(x => x.Cards)
            .FirstOrDefault(x => x.ID == data.FlashCardCollectionID);

        if (entity == null)
            throw new Exception("Coleção de flash card não encontrada.");

        entity.EditCardItem(
            flashCardItemID: data.FlashCardItemID,
            frontDescription: data.FrontDescription,
            verseDescription: data.VerseDescription);

        return Task.CompletedTask;
    }

    public async Task<FlashCardCollectionDto> GetByIDAsync(int flashcardCollectionID)
    {
        var flashcard = await _context.FlashCards
            .Include(x => x.Cards)
            .Include(x => x.Ratings)
            .Include(x => x.UserDirectory)
                .ThenInclude(x => x.User)
            .FirstAsync(x => x.ID == flashcardCollectionID);

        var result = new FlashCardCollectionDto(flashcard);

        return result;
    }

    public async Task<IEnumerable<FlashCardCollectionDto>> GetByUserIDAsync(int userID)
    {
        var directories = _context.Directories
            .Where(x => x.UserID == userID)
            .Select(x => x.ID);

        var flashCards = await _context.FlashCards
            .Include(x => x.Cards)
            .Include(x => x.Ratings)
            .Include(x => x.UserDirectory)
                .ThenInclude(x => x.User)
            .Where(x => directories.Contains(x.UserDirectoryID))
            .ToListAsync();

        var result = flashCards.Select(x => new FlashCardCollectionDto(x));

        return result;
    }

    public Task<IEnumerable<FlashCardRatingDto>> GetCardRatingByIDAsync(int flashcardCollectionID)
    {
        var entity = _context.FlashCards
            .Include(x => x.Ratings)
                .ThenInclude(x => x.User)
            .FirstOrDefault(x => x.ID == flashcardCollectionID);

        if (entity == null)
            throw new Exception("Coleção de flash card não encontrada.");

        var result = entity.Ratings.Select(x => new FlashCardRatingDto(x));

        return Task.FromResult(result);
    }

    public Task RemoveCardAsync(RemoveFlashCardItemDto data)
    {
        var entity = _context.FlashCards
            .Include(x => x.Cards)
            .FirstOrDefault(x => x.ID == data.FlashCardCollectionID);

        if (entity == null)
            throw new Exception("Coleção de flash card não encontrada.");

        entity.RemoveCardItem(
            flashCardItemID: data.FlashCardItemID);

        return Task.CompletedTask;
    }

    private FlashCardCollection GetByID(int id)
    {
        var entity = _context.FlashCards
            .Include(x => x.Tags)
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Coleção de flash card não encontrada.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
