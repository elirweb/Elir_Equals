using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Domain.Common
{
   
        public interface IRepository<T> where T : Base.Entity
        {
            void Add(T entity);
           


        
    }
}
