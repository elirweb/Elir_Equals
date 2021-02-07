using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Mapper
{
    public static class Acquirer
    {

        public static Equals_Domain.Entites.Acquirer Acquirers(Equals_DomainService.Entites.Acquirer model)
        {
            var _acquirer = new Equals_Domain.Entites.Acquirer();
            if (model is null) throw new Exception();

             _acquirer= new Equals_Domain.Entites.Acquirer(model.TipoRegistro, model.Estabelecimento,
                model.DataProcessamento, model.PeriodoInicial, model.PeriodoFinal, model.Sequencial, model.Adquirente);

            return _acquirer;
        }

     

        

       
    }
}
