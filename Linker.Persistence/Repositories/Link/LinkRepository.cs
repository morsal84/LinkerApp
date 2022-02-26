using Linker.Application.Repositories.Link;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker.Persistence.Repositories.Link
{
    public class LinkRepository : ReadRepository<Domain.Entities.Link>, ILinkRepository
    {
        private readonly LinkerContext _context;

        public LinkRepository(LinkerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Link> GetByAbrevationAsync(string abrevation)
        {
            return await _context.Links.FirstOrDefaultAsync(c => c.Abrevation == abrevation);
        }
    }
}
