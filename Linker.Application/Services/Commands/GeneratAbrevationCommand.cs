using Linker.Application.Repositories;
using Linker.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Linker.Application.Services.Commands
{
    public class GeneratAbrevationCommand : IRequest<string>
    {
        private class Handler : IRequestHandler<GeneratAbrevationCommand, string>
        {
            private readonly IReadRepository<Link> _linkRepository;
            private readonly IMediator _mediator;

            public Handler(IReadRepository<Link> linkRepository, IMediator mediator)
            {
                _linkRepository = linkRepository;
                _mediator = mediator;
            }

            public async Task<string> Handle(GeneratAbrevationCommand command, CancellationToken cancellationToken)
            {
                Random random = new Random();
                const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var abrivation = new string(Enumerable.Repeat(characters, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                if (_linkRepository.TableNoTracking.Any(c => c.Abrevation == abrivation))
                {
                    abrivation = await _mediator.Send(new GeneratAbrevationCommand());
                }
                return abrivation;
            }
        }
    }
}
