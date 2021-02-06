using Equals_Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Equals_Infra.Common
{
    public class RepositoryBase<T>: Equals_Domain.Common.IRepository<T> where T: Equals_Domain.Base.Entity
    {
        protected readonly EfCore _context;
        protected readonly DbSet<T> Entity = null;

        public RepositoryBase(EfCore ef)
        {
            _context = ef;
            Entity = _context.Set<T>();

        }
        public void Add(T entity)
        {
            entity.Created = DateTime.Now;
            entity.Hours = DateTime.Now.ToShortTimeString();
            Entity.Add(entity);



        }

       


    }
}
