using Linker.Domain;
using Linker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linker.Application.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}
