using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Interfaces
{
    public interface IAcquirer
    {
        Equals_DomainService.Entites.Acquirer Add(Input.Acquirer model);
    }
}
