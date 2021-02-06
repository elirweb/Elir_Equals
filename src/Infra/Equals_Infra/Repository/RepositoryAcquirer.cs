using System;

namespace Equals_Infra.Repository
{
    public class RepositoryAcquirer : Common.RepositoryBase<Equals_Domain.Entites.Acquirer>, Equals_Domain.Interfaces.IAcquirer
    {
        public RepositoryAcquirer(Context.EfCore ef) : base(ef)
        {}
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
