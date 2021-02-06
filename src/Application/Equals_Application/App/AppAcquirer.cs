using System;
using System.Collections.Generic;
using System.Text;
using Equals_Application.ViewModel;

namespace Equals_Application.App
{
    public class AppAcquirer : Service.ServiceAcquirer, Interfaces.IAcquirer
    {
        public AppAcquirer(Equals_Infra.Uow.IUoW ou): base(ou)
        {

        }
        public Acquirer Add(Acquirer model)
        {
            // implentar a regra de negocio do projeto
            throw new NotImplementedException();
        }
    }
}
