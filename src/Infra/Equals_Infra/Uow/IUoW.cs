using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Infra.Uow
{
    public interface IUoW
    {
        void Commit();
        void Rolback();

        Equals_Domain.Interfaces.IAcquirer Acquirer { get; }
         Equals_Domain.Interfaces.IFile File { get; }

    }
}
