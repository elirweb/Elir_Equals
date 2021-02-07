using System;
using System.Collections.Generic;
using System.Text;

namespace Equals_Application.Mapper
{
    public static class Acquirer
    {

        public static Equals_Domain.Entites.Acquirer Acquirers(List<Equals_DomainService.Entites.Acquirer> model)
        {
            var _acquirer = new Equals_Domain.Entites.Acquirer();
            if (model.Count == 0) throw new Exception();

            model.ForEach(item=> _acquirer= new Equals_Domain.Entites.Acquirer( item.TipoRegistro,item.Estabelecimento, 
                item.DataProcessamento,item.PeriodoInicial, item.PeriodoFinal, item.Sequencial, item.Adquirente));

            return _acquirer;
        }

     

        

       
    }
}
