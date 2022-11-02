using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Service.Tests.Services;

public class SubscriptionTypeServiceTests
{
    private const int DefaultUserID = -1;

    private static readonly Random _random = new();
    private static readonly ApplicationDbContextFactory _contextFactory = new();

    [Fact]
    public async Task OnGetAllSubscriptionTypes_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);

        IEnumerable<SubscriptionTypeDto> subscriptionTypes = await objectTesting.GetAllAsync();

        Assert.NotEmpty(subscriptionTypes);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnGetAllSubscriptionTypesByUserID_WhenExistData_ShouldReturnListFilled()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);

        IEnumerable<SubscriptionTypeByUserDto> subscriptionTypes = await objectTesting.GetAllByUserAsync(DefaultUserID);

        Assert.NotEmpty(subscriptionTypes);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }


    [Fact]
    public async Task OnGetSubscriptionTypeByID_WhenExistData_ShouldReturnData()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);

        SubscriptionTypeDto subscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.NotNull(subscriptionType);
        Assert.Equal(createDto.Name, subscriptionType.Name);
        Assert.Equal(createDto.Price, subscriptionType.Price);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnCreateSubscriptionType_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);
        SubscriptionTypeDto newSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.NotNull(newSubscriptionType);
        Assert.Equal(createDto.Name, newSubscriptionType.Name);
        Assert.Equal(createDto.Price, newSubscriptionType.Price);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnEditSubscriptionType_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);
        SubscriptionTypeDto oldSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.NotNull(oldSubscriptionType);
        Assert.Equal(createDto.Name, oldSubscriptionType.Name);
        Assert.Equal(createDto.Price, oldSubscriptionType.Price);

        EditSubscriptionTypeDto editDto = new(
            id: oldSubscriptionType.ID,
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        await objectTesting.EditAsync(editDto);
        SubscriptionTypeDto updatedSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.NotNull(updatedSubscriptionType);

        Assert.Equal(oldSubscriptionType.ID, updatedSubscriptionType.ID);
        Assert.NotEqual(oldSubscriptionType.Name, updatedSubscriptionType.Name);
        Assert.NotEqual(oldSubscriptionType.Price, updatedSubscriptionType.Price);

        Assert.Equal(editDto.Name, updatedSubscriptionType.Name);
        Assert.Equal(editDto.Price, updatedSubscriptionType.Price);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnDeleteSubscriptionType_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);
        SubscriptionTypeDto subscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.NotNull(subscriptionType);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));

        Task action() => objectTesting.GetByIDAsync(subscriptionTypeID);
        Exception result = await Assert.ThrowsAsync<Exception>(action);

        Assert.Equal("Tipo de assinatura não encontrado.", result.Message);
    }

    [Fact]
    public async Task OnAddSubscriptionTypeBenefit_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);
        SubscriptionTypeDto beforeSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Empty(beforeSubscriptionType.Benefits);

        AddSubscriptionTypeBenefitDto addBenefitDto = new(
            subscriptionTypeID: subscriptionTypeID,
            benefit: _random.Next().ToString());

        int benefitID = await objectTesting.AddBenefitAsync(addBenefitDto);

        SubscriptionTypeDto afterSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Single(afterSubscriptionType.Benefits);
        Assert.Equal(benefitID, afterSubscriptionType.Benefits.Single().ID);
        Assert.Equal(addBenefitDto.Benefit, afterSubscriptionType.Benefits.Single().Benefit);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnEditSubscriptionTypeBenefit_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);

        AddSubscriptionTypeBenefitDto addBenefitDto = new(
            subscriptionTypeID: subscriptionTypeID,
            benefit: _random.Next().ToString());

        int benefitID = await objectTesting.AddBenefitAsync(addBenefitDto);

        SubscriptionTypeDto beforeSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Single(beforeSubscriptionType.Benefits);
        Assert.Equal(addBenefitDto.Benefit, beforeSubscriptionType.Benefits.Single().Benefit);

        EditSubscriptionTypeBenefitDto editBenefitDto = new(
            subscriptionTypeID: subscriptionTypeID,
            subscriptionTypeBenefitID: benefitID,
            benefit: _random.Next().ToString());

        await objectTesting.EditBenefitAsync(editBenefitDto);

        SubscriptionTypeDto afterSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Single(beforeSubscriptionType.Benefits);
        Assert.Equal(benefitID, beforeSubscriptionType.Benefits.Single().ID);
        Assert.Equal(editBenefitDto.Benefit, beforeSubscriptionType.Benefits.Single().Benefit);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }

    [Fact]
    public async Task OnDeleteSubscriptionTypeBenefit_WhenDataIsValid_ShouldUpdateDatabase()
    {
        using ApplicationDbContext context = _contextFactory.CreateContext();
        ISubscriptionTypeService objectTesting = new SubscriptionTypeService(context);

        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.NextDouble());

        int subscriptionTypeID = await objectTesting.CreateAsync(createDto);

        AddSubscriptionTypeBenefitDto addBenefitDto = new(
            subscriptionTypeID: subscriptionTypeID,
            benefit: _random.Next().ToString());

        int benefitID = await objectTesting.AddBenefitAsync(addBenefitDto);

        SubscriptionTypeDto beforeSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Single(beforeSubscriptionType.Benefits);
        Assert.Equal(addBenefitDto.Benefit, beforeSubscriptionType.Benefits.Single().Benefit);

        RemoveSubscriptionTypeBenefitDto removeBenefitDto = new(
            subscriptionTypeID: subscriptionTypeID,
            subscriptionTypeBenefitID: benefitID);

        await objectTesting.RemoveBenefitAsync(removeBenefitDto);

        SubscriptionTypeDto afterSubscriptionType = await objectTesting.GetByIDAsync(subscriptionTypeID);

        Assert.Empty(beforeSubscriptionType.Benefits);

        await objectTesting.DeleteAsync(new DeleteSubscriptionTypeDto(subscriptionTypeID));
    }
}
