using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Pretender.Server
{
    public class PretenderController<T> : Controller where T : Controller
    {
        private readonly IMediator _mediator;

        public PretenderController(IMediator mediator, ILogger<T> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ILogger<T> Logger { get; }

        public async Task<IActionResult> Mediate<TRequest>(IRequest<TRequest> request)
        {
            try
            {
                return Json(await _mediator.Send(request).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
