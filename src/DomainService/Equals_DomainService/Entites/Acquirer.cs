using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Equals_DomainService.Entites
{
    public class Acquirer
    {
        
        public string TipoRegistro { get; private set; }
        public string Estabelecimento { get; private set; }
        public string DataProcessamento { get; set; }
        public string PeriodoInicial { get; set; }
        public string PeriodoFinal { get; private set; }
        public string Sequencial { get; private set; }
        public string Adquirente { get; private set; }
        public Equals_Util.Enums.Status Status { get;  set; }
        public Acquirer()
        {

        }

        public Acquirer( string tipo, string estabelecimento, string dataproc, string periodoini, string periodofi, string sequencial, string adq)
        {
            if (adq.Equals("FagammonCard"))
            {
                TipoRegistro = tipo;
                DataProcessamento = dataproc;
                Estabelecimento = estabelecimento;
                Adquirente = adq;
                Sequencial = sequencial.Length > 6 ? sequencial.Substring(0, 7) : sequencial;
            }
            else {
                TipoRegistro = tipo;
                Estabelecimento = estabelecimento;
                DataProcessamento = dataproc;
                PeriodoInicial = periodoini;
                PeriodoFinal = periodofi;
                Sequencial = sequencial.Length > 7 ? sequencial.Substring(0,7):sequencial;
                Adquirente = adq;
            }
        }
    }
}