using Linker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Linker.Application.Repositories
{
    public interface ILinker
    {
        Task<Link> GetLinkByIdAsync(Guid id);

        Task<int> UpdateLinkAsync(Link link);

        Task<int> InsertLinkAsync(Link link);

        Task DeleteLinkAsync(Link link);


    }
}
