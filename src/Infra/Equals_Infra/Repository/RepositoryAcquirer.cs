using System;
using System.Collections.Generic;
using System.Linq;
using Equals_Domain.Entites;

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

        public List<Acquirer> Get(DateTime date)
            => _context.Acquirer.Where(c=>c.PeriodoInicial.Equals(date.ToString("yyyyMMdd"))).ToList();

       
    }
}
