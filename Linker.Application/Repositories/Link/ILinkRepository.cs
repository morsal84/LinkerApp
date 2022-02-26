using System.Threading.Tasks;

namespace Linker.Application.Repositories.Link
{
    public interface ILinkRepository<T> : IReadRepository<Domain.Entities.Link>
    {
        Task<Domain.Entities.Link> GetByShortLinkAsync(string abrevation);
    }
}
