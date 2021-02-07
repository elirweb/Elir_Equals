using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Interfaces
{
    public interface IFile
    {
        Equals_DomainService.Entites.File Add(Input.Acquirer model);
        Equals_DomainService.Entites.File File(string adq);
    }
}
