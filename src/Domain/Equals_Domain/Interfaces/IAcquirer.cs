using Equals_Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Domain.Interfaces
{
    public interface IAcquirer: Common.IRepository<Acquirer>, IDisposable
    {
        List<Equals_Domain.Entites.Acquirer> Get(DateTime date);
    }
}
