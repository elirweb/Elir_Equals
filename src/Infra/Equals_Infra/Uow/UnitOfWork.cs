using System;
using System.Collections.Generic;
using System.Text;
using Equals_Domain.Entites;
using Equals_Domain.Interfaces;

namespace Equals_Infra.Uow
{
    public class UnitOfWork : IUoW
    {
        private readonly Context.EfCore _repository;

        public UnitOfWork(Context.EfCore cont)
        {
            _repository = cont;
            Acquirer = new Repository.RepositoryAcquirer(_repository);
        }

        public IAcquirer Acquirer { get; private set; }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rolback()
        {
            throw new NotImplementedException();
        }
    }
}
