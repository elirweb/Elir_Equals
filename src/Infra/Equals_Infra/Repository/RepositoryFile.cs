using Equals_Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Equals_Infra.Repository
{
    public class RepositoryFile : Common.RepositoryBase<Equals_Domain.Entites.File>, Equals_Domain.Interfaces.IFile
    {
       
        public RepositoryFile(Context.EfCore ef) : base(ef)
        {
           
        }
        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public List<File> Get(string adq)
           => _context.File.Where(c=>c.Acquirer.Adquirente.Equals(adq)).ToList();



    }
}
