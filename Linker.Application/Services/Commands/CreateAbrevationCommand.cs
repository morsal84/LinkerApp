using Linker.Application.Repositories;
using Linker.Domain.Entities;
using MediatR;
using ShortLink.Service.Features.Links.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linker.Application.Services.Commands
{
    public class CreateAbrevationCommand : IRequest<AbrevationDto>
    {
        public string Url { get; set; }

        private class Handler : IRequestHandler<CreateAbrevationCommand, AbrevationDto>
        {
            private readonly IWriteRepository<Link> _linkRepository;
            private readonly IMediator _mediator;
            public Handler(IWriteRepository<Link> linkRepository, IMediator mediator)
            {
                _linkRepository = linkRepository;
                _mediator = mediator;
            }

            public async Task<AbrevationDto> Handle(CreateAbrevationCommand command, CancellationToken cancellationToken)
            {
                var abrevation = await _mediator.Send(new GeneratAbrevationCommand());

                var link = new Link
                {
                    Url = command.Url,
                    Abrevation = abrevation
                };
                await _linkRepository.CreateAsync(link);
                await _linkRepository.SaveChangeAsync();

                return new AbrevationDto { Abrevation = abrevation };
            }
        }
    }
}
