using FlashCards.Api.Core.SubscriptionTypes;
using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Service.Services;

public class SubscriptionTypeService : ISubscriptionTypeService
{
    private readonly ApplicationDbContext _context;

    public SubscriptionTypeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubscriptionTypeDto>> GetAllAsync()
    {
        var subscription = await _context.SubscriptionTypes
            .Include(x => x.Benefits)
            .OrderBy(x => x.Price)
            .ToListAsync();

        var result = subscription.Select(x => new SubscriptionTypeDto(x));

        return result;
    }

    public async Task<IEnumerable<SubscriptionTypeByUserDto>> GetAllByUserAsync(int userID)
    {
        var user = _context.Users.FirstOrDefault(x => x.ID == userID);

        if (user == null)
            throw new Exception("Usuário não encontrado.");

        var subscription = await _context.SubscriptionTypes
            .Include(x => x.Benefits)
            .OrderBy(x => x.Price)
            .ToListAsync();

        var result = subscription.Select(x => new SubscriptionTypeByUserDto(x, user));

        return result;
    }

    public Task<SubscriptionTypeDto> GetByIDAsync(int subscriptionTypeID)
    {
        var entity = GetByIDWithBenefits(subscriptionTypeID);

        var result = new SubscriptionTypeDto(entity);

        return Task.FromResult(result);
    }

    public async Task<int> CreateAsync(CreateSubscriptionTypeDto data)
    {
        var entity = new SubscriptionType(data.Name, data.Price);

        _context.Add(entity);

        await SaveChangesAsync();

        return entity.ID;
    }

    public async Task EditAsync(EditSubscriptionTypeDto data)
    {
        var entity = GetByIDWithBenefits(data.ID);

        entity.Edit(data.Name, data.Price);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task DeleteAsync(DeleteSubscriptionTypeDto data)
    {
        var entity = GetByIDWithBenefits(data.ID);

        _context.Remove(entity);

        await SaveChangesAsync();
    }

    public async Task<int> AddBenefitAsync(AddSubscriptionTypeBenefitDto data)
    {
        var entity = GetByIDWithBenefits(data.SubscriptionTypeID);

        entity.AddBenefit(data.Benefit);

        _context.Update(entity);

        await SaveChangesAsync();

        return entity.Benefits.First(x => x.Benefit == data.Benefit).ID;
    }

    public async Task EditBenefitAsync(EditSubscriptionTypeBenefitDto data)
    {
        var entity = GetByIDWithBenefits(data.SubscriptionTypeID);

        entity.EditBenefit(data.SubscriptionTypeBenefitID, data.Benefit);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    public async Task RemoveBenefitAsync(RemoveSubscriptionTypeBenefitDto data)
    {
        var entity = GetByIDWithBenefits(data.SubscriptionTypeID);

        entity.RemoveBenefit(data.SubscriptionTypeBenefitID);

        _context.Update(entity);

        await SaveChangesAsync();
    }

    private SubscriptionType GetByIDWithBenefits(int id)
    {
        var entity = _context.SubscriptionTypes
            .Include(x => x.Benefits)
            .FirstOrDefault(x => x.ID == id);

        if (entity != null)
            return entity;

        throw new Exception("Tipo de assinatura não encontrado.");
    }

    private async Task SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();

        if (result <= 0)
            throw new Exception("Ocorreu um erro ao salvar os dados. Tente novamente.");
    }
}
