using System.Collections.Generic;
using System.Linq;
using Equals_DomainService.Entites;

namespace Equals_Application.App
{
    public class AppFile : Service.ServiceFile, Interfaces.IFile
    {
        private List<Equals_Domain.Entites.Acquirer> Acquirers = new List<Equals_Domain.Entites.Acquirer>();
        private List<Equals_Domain.Entites.File> Files = new List<Equals_Domain.Entites.File>();

        private Equals_DomainService.Entites.File _files = new Equals_DomainService.Entites.File();
        public AppFile(Equals_Infra.Uow.IUoW ou) : base(ou)
        {

        }
        public Equals_DomainService.Entites.File Add(Input.Acquirer model)
        {
            int day = 0;
            if (model.Periodicidade.Equals(Equals_Util.Enums.Periodicidade.Diario.ToString()))
            {
                Acquirers = _context.Acquirer.Get(model.Date);
                if (Acquirers.Count > 0)
                {

                    _files.ListAcquirer.Add(Mapper.File.Acquirers(Acquirers));

                    _context.File.Add(Mapper.File.Files(Acquirers));
                    _context.Commit();
                }
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    Acquirers = _context.Acquirer.Get(model.Date.AddDays(day));
                    if (Acquirers.Count > 0)
                    {

                        _files.ListAcquirer.Add(Mapper.File.Acquirers(Acquirers));

                        _context.File.Add(Mapper.File.Files(Acquirers));
                        _context.Commit();
                    }
                    day = 7;
                }
            }
            return _files;


        }

        public File File(string adq)
        {
            Files = _context.File.Get(adq);
            var _file = new File();

            if (Files.Count > 0) 
                _file.StatusFile = $"{Files.Count} arquivos foram recepcionados";
            else
                _file.StatusFile = $"{Files.Count} arquivos não foram recepcionados";

            return _file;
        }
    }
}
