using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Mapper
{
    public static class File
    {
        public static Equals_Domain.Entites.File Files(List<Equals_Domain.Entites.Acquirer> model)
        {
            var _acquirer = new Equals_Domain.Entites.File();
            if (model.Count == 0) throw new Exception();

            model.ForEach(item => _acquirer = new Equals_Domain.Entites.File(item.Id,"processados"));

            return _acquirer;
        }


        public static Equals_DomainService.Entites.Acquirer Acquirers(List<Equals_Domain.Entites.Acquirer> model)
        {
            var _acquirer = new Equals_DomainService.Entites.Acquirer();
            if (model.Count == 0) throw new Exception();

            model.ForEach(item => _acquirer = new Equals_DomainService.Entites.Acquirer(item.TipoRegistro, item.Estabelecimento,
               item.DataProcessamento, item.PeriodoInicial, item.PeriodoFinal, item.Sequencial, item.Adquirente));


            return _acquirer;
        }
    }
}
