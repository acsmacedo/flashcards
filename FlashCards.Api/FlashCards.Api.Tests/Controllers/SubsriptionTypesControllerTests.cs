using FlashCards.Api.Core.SubscriptionTypes;
using FlashCards.Api.Core.Users;
using FlashCards.Api.Service.DTO.SubscriptionTypes;

namespace FlashCards.Api.Tests.Controllers;

public class SubsriptionTypesControllerTests
{
    private readonly SubscriptionTypesController _objectTesting;
    private readonly Mock<ISubscriptionTypeService> _mockService;

    private static readonly Random _random = new();

    public SubsriptionTypesControllerTests()
    {
        _mockService = new Mock<ISubscriptionTypeService>();
        _objectTesting = new SubscriptionTypesController(_mockService.Object);
    }

    [Fact]
    public async Task OnGetAllSubscriptionTypes_ShouldReturnOkResult()
    {
        IEnumerable<SubscriptionTypeDto> subscriptionTypes = GenerateSubscriptionTypes();

        _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(subscriptionTypes);

        IActionResult response = await _objectTesting.GetAllAsync();

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(subscriptionTypes);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task OnGetAllSubscriptionTypesByUserID_ShouldReturnOkResult()
    {
        IEnumerable<SubscriptionTypeByUserDto> subscriptionTypes = GenerateSubscriptionTypesByUser();
        int userID = _random.Next();

        _mockService.Setup(x => x.GetAllByUserAsync(userID)).ReturnsAsync(subscriptionTypes);

        IActionResult response = await _objectTesting.GetAllByUserIDAsync(userID);

        OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(response);

        string resultData = JsonConvert.SerializeObject(objectResponse.Value);
        string expectedData = JsonConvert.SerializeObject(subscriptionTypes);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.GetAllByUserAsync(userID), Times.Once);
    }

    [Fact]
    public async Task OnCreateSubscriptionType_ShouldReturnOkResult()
    {
        CreateSubscriptionTypeDto createDto = new(
            name: _random.Next().ToString(),
            price: _random.Next());

        CreateSubscriptionTypeDto? resultDto = null;

        _mockService
            .Setup(x => x.CreateAsync(It.IsAny<CreateSubscriptionTypeDto>()))
            .Callback((CreateSubscriptionTypeDto x) => resultDto = x);

        IActionResult response = await _objectTesting.CreateAsync(createDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(createDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.CreateAsync(It.IsAny<CreateSubscriptionTypeDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditSubscriptionType_ShouldReturnOkResult()
    {
        EditSubscriptionTypeDto editDto = new(
            id: _random.Next(),
            name: _random.Next().ToString(),
            price: _random.Next());

        EditSubscriptionTypeDto? resultDto = null;

        _mockService
            .Setup(x => x.EditAsync(It.IsAny<EditSubscriptionTypeDto>()))
            .Callback((EditSubscriptionTypeDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditAsync(editDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditAsync(It.IsAny<EditSubscriptionTypeDto>()), Times.Once);
    }

    [Fact]
    public async Task OnDeleteSubscriptionType_ShouldReturnOkResult()
    {
        DeleteSubscriptionTypeDto deleteDto = new(_random.Next());
        DeleteSubscriptionTypeDto? resultDto = null;

        _mockService
            .Setup(x => x.DeleteAsync(It.IsAny<DeleteSubscriptionTypeDto>()))
            .Callback((DeleteSubscriptionTypeDto x) => resultDto = x);

        IActionResult response = await _objectTesting.DeleteAsync(deleteDto.ID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(deleteDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.DeleteAsync(It.IsAny<DeleteSubscriptionTypeDto>()), Times.Once);
    }

    [Fact]
    public async Task OnAddSubscriptionTypeBenefit_ShouldReturnOkResult()
    {
        AddSubscriptionTypeBenefitDto addBenefitDto = new(
            subscriptionTypeID: _random.Next(),
            benefit: _random.Next().ToString());

        AddSubscriptionTypeBenefitDto? resultDto = null;

        _mockService
            .Setup(x => x.AddBenefitAsync(It.IsAny<AddSubscriptionTypeBenefitDto>()))
            .Callback((AddSubscriptionTypeBenefitDto x) => resultDto = x);

        IActionResult response = await _objectTesting.AddBenefitAsync(addBenefitDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(addBenefitDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.AddBenefitAsync(It.IsAny<AddSubscriptionTypeBenefitDto>()), Times.Once);
    }

    [Fact]
    public async Task OnEditSubscriptionTypeBenefit_ShouldReturnOkResult()
    {
        EditSubscriptionTypeBenefitDto editBenefitDto = new(
            subscriptionTypeID: _random.Next(),
            subscriptionTypeBenefitID: _random.Next(),
            benefit: _random.Next().ToString());

        EditSubscriptionTypeBenefitDto? resultDto = null;

        _mockService
            .Setup(x => x.EditBenefitAsync(It.IsAny<EditSubscriptionTypeBenefitDto>()))
            .Callback((EditSubscriptionTypeBenefitDto x) => resultDto = x);

        IActionResult response = await _objectTesting.EditBenefitAsync(editBenefitDto);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(editBenefitDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.EditBenefitAsync(It.IsAny<EditSubscriptionTypeBenefitDto>()), Times.Once);
    }

    [Fact]
    public async Task OnRemoveSubscriptionTypeBenefit_ShouldReturnOkResult()
    {
        RemoveSubscriptionTypeBenefitDto removeBenefitDto = new(
            subscriptionTypeID: _random.Next(), 
            subscriptionTypeBenefitID: _random.Next());

        RemoveSubscriptionTypeBenefitDto? resultDto = null;

        _mockService
            .Setup(x => x.RemoveBenefitAsync(It.IsAny<RemoveSubscriptionTypeBenefitDto>()))
            .Callback((RemoveSubscriptionTypeBenefitDto x) => resultDto = x);

        IActionResult response = await _objectTesting.RemoveBenefitAsync(
            subscriptionTypeID: removeBenefitDto.SubscriptionTypeID,
            subscriptionTypeBenefitID: removeBenefitDto.SubscriptionTypeBenefitID);

        OkResult objectResponse = Assert.IsType<OkResult>(response);

        string resultData = JsonConvert.SerializeObject(resultDto);
        string expectedData = JsonConvert.SerializeObject(removeBenefitDto);

        Assert.Equal(expectedData, resultData);

        _mockService.Verify(x => x.RemoveBenefitAsync(It.IsAny<RemoveSubscriptionTypeBenefitDto>()), Times.Once);
    }

    private static IEnumerable<SubscriptionTypeDto> GenerateSubscriptionTypes(int count = 5)
    {
        List<SubscriptionTypeDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateSubscriptionType());
        }

        return result;
    }

    private static SubscriptionTypeDto GenerateSubscriptionType()
    {
        var subscriptionType = new SubscriptionType(
            id: _random.Next(),
            name: _random.Next().ToString(),
            price: _random.Next());

        return new SubscriptionTypeDto(subscriptionType);
    }

    private static IEnumerable<SubscriptionTypeByUserDto> GenerateSubscriptionTypesByUser(int count = 5)
    {
        List<SubscriptionTypeByUserDto> result = new();

        for (int i = 0; i < count; i++)
        {
            result.Add(GenerateSubscriptionTypeByUser());
        }

        return result;
    }

    private static SubscriptionTypeByUserDto GenerateSubscriptionTypeByUser()
    {
        var subscriptionType = new SubscriptionType(
            id: _random.Next(),
            name: _random.Next().ToString(),
            price: _random.Next());

        var user = new User(
            id: _random.Next(),
            name: _random.Next().ToString());

        return new SubscriptionTypeByUserDto(subscriptionType, user);
    }
}
