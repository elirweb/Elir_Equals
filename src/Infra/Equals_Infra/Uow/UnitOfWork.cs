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
            File = new Repository.RepositoryFile(_repository);
        }

        public IAcquirer Acquirer { get; private set; }

        public IFile File { get; private set; }

        public void Commit()
        {
            _repository.SaveChanges();
        }

        public void Rolback()
        {
            _repository.Database.RollbackTransaction();
        }
    }
}
