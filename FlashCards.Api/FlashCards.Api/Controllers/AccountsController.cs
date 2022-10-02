using FlashCards.Api.Core.Accounts;
using FlashCards.Api.Service.DTO.Accounts;

namespace FlashCards.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUpAsync(CreateAccountDto data)
        {
            var result = await _service.CreateAsync(data);

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginAccountDto data)
        {
            var result = await _service.LoginAsync(data);

            return Ok(result);
        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangeAccountPasswordDto data)
        {
            await _service.ChangePasswordAsync(data);

            return Ok();
        }

        [HttpPut]
        [Route("Disable")]
        public async Task<IActionResult> DisableAsync(DisableAccountDto data)
        {
            await _service.DisableAsync(data);

            return Ok();
        }

        [HttpDelete]
        [Route("{accountID}")]
        public async Task<IActionResult> DeleteAsync(int accountID)
        {
            await _service.DeleteAsync(new DeleteAccountDto(accountID));

            return Ok();
        }
    }
}
