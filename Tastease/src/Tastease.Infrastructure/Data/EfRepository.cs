using Ardalis.Specification.EntityFrameworkCore;
using Tastease.Infrastructure.Data.CoreContext;
using Tastease.SharedKernel.Interfaces;

namespace Tastease.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(CoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
