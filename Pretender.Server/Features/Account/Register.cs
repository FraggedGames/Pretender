using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pretender.Features.Account
{
    public class Register
    {
        public class Request : IRequest<Response>
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Email { get; set; }
            public String Password { get; set; }
            public Boolean RememberLogin { get; set; }
        }

        public class RequestValidator : AbstractValidator<Request>
        {
            private readonly AccountOptions _options;

            public RequestValidator(IOptions<AccountOptions> options)
            {
                _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
                RuleFor(x => x.FirstName).NotEmpty().MaximumLength(128);
                RuleFor(x => x.LastName).NotEmpty().MaximumLength(128);
                RuleFor(x => x.Email).EmailAddress().MaximumLength(128);
                RuleFor(x => x.Password).Length(_options.MinimumPasswordLength, _options.MaximumPasswordLength);
            }
        }

        public class Response
        {
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new Response());
            }
        }
    }
}
