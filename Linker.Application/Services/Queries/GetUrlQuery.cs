using Linker.Application.Repositories;
using Linker.Application.Repositories.Link;
using Linker.Domain.Entities;
using MediatR;
using ShortLink.Service.Features.Links.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linker.Application.Services.Queries
{
    public class GetUrlQuery : IRequest<UrlDto>
    {
        public string Abrevation { get; set; }

        private class Handler : IRequestHandler<GetUrlQuery, UrlDto>
        {
            private readonly ILinkRepository _linkRepository;
            private readonly IWriteRepository<Link> _linkWriteRepository;


            public Handler(ILinkRepository LinksRepository, IWriteRepository<Link> linkWriteRepository)
            {
                _linkRepository = LinksRepository;
                _linkWriteRepository = linkWriteRepository;
            }

            public async Task<UrlDto> Handle(GetUrlQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var link = await _linkRepository.GetByAbrevationAsync(request.Abrevation);

                    if (link == null)
                        return null;

                    link.Visits = link.Visits + 1;

                    _linkWriteRepository.Update(link);
                    await _linkWriteRepository.SaveChangeAsync();

                    return new UrlDto { Url = link.Url };
                }
                catch (Exception e)
                {
                    throw;
                }
               
            }
        }
    }
}
