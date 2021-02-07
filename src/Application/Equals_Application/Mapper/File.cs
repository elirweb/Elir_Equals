using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Mapper
{
    public static class File
    {
        public static Equals_Domain.Entites.File Files(Equals_Domain.Entites.Acquirer model)
        {
            var _acquirer = new Equals_Domain.Entites.File();
            if (model is  null) throw new Exception();

             _acquirer = new Equals_Domain.Entites.File(model.Id,"processados");

            return _acquirer;
        }


        public static Equals_Domain.Entites.Acquirer Acquirers(Equals_Domain.Entites.Acquirer model)
        {
            var _acquirer = new Equals_Domain.Entites.Acquirer();
            if (model is null) throw new Exception();

             _acquirer = new Equals_Domain.Entites.Acquirer(model.TipoRegistro, model.Estabelecimento,
               model.DataProcessamento, model.PeriodoInicial, model.PeriodoFinal, model.Sequencial, model.Adquirente);


            return _acquirer;
        }
    }
}
