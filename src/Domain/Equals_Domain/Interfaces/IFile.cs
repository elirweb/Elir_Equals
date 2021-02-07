using Equals_Domain.Entites;
using System;
using System.Collections.Generic;

namespace Equals_Domain.Interfaces
{
    public interface IFile : Common.IRepository<File>, IDisposable
    {
        List<Equals_Domain.Entites.File> Get(string adq);
    }
}
