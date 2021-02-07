using System.Collections.Generic;
using System.Linq;
using Equals_DomainService.Entites;

namespace Equals_Application.App
{
    public class AppFile : Service.ServiceFile, Interfaces.IFile
    {
        private  List<Equals_Domain.Entites.Acquirer> Acquirers = new List<Equals_Domain.Entites.Acquirer>();
        private  List<Equals_Domain.Entites.File> Files = new List<Equals_Domain.Entites.File>();

        private Equals_DomainService.Entites.File _files = new File();
        public AppFile(Equals_Infra.Uow.IUoW ou) : base(ou)
        {

        }
        public Equals_DomainService.Entites.File Add(Input.Acquirer model)
        {
            
            if (model.Periodicidade.Equals(Equals_Util.Enums.Periodicidade.Diario.ToString()))
            {

                Acquirers = _context.Acquirer.Get(model.Date);
                foreach (var item in Acquirers)
                {
                    _files.DateFile = model.Date.ToString("yyyyMMdd");
                    _context.File.Add(Mapper.File.Files(item));
                    _context.Commit();

                }
            }
            else
            {

                Acquirers = _context.Acquirer.Get(model.Date.AddDays(7));
                foreach (var item in Acquirers)
                {
                    _files.DateFile = model.Date.ToString("yyyyMMdd");
                    _context.File.Add(Mapper.File.Files(item));
                    _context.Commit();
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
