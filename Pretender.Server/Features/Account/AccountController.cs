using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pretender.Features.Account;
using System.Threading.Tasks;

namespace Pretender.Server.Features.Account
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : PretenderController<AccountController>
    {
        public AccountController(IMediator mediator, ILogger<AccountController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public IActionResult Index() => Json("Hello World!");

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]Login.Request request) => await Mediate(request).ConfigureAwait(false);

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register.Request request) => await Mediate(request).ConfigureAwait(false);
    }
}
