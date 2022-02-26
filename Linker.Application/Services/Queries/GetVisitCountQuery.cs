using Linker.Application.Repositories.Link;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Linker.Application.Services.Queries
{
    public class GetVisitCountQuery : IRequest<long>
    {
        public string Abrevation { get; set; }

        private class Handler : IRequestHandler<GetVisitCountQuery, long>
        {
            private readonly ILinkRepository _linkRepository;


            public Handler(ILinkRepository LinksRepository)
            {
                _linkRepository = LinksRepository;
            }

            public async Task<long> Handle(GetVisitCountQuery request, CancellationToken cancellationToken)
            {
                var link = await _linkRepository.GetByShortLinkAsync(request.Abrevation);
                return link.Visits;
            }
        }
    }
}
