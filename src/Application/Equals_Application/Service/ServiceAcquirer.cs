using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Service
{
    public class ServiceAcquirer
    {
        protected readonly Equals_Infra.Uow.IUoW _context;


        public ServiceAcquirer(Equals_Infra.Uow.IUoW ou)
        {
            _context = ou;

        }
    }
}
