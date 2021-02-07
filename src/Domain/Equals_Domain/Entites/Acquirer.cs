namespace Equals_Domain.Entites
{
    public class Acquirer : Base.Entity
    {
        public string TipoRegistro { get; private set; }
        public string Estabelecimento { get; private set; }
        public string DataProcessamento { get; private set; }
        public string PeriodoInicial { get; private set; }
        public string PeriodoFinal { get; private set; }
        public string Sequencial { get; private set; }
        public string Adquirente { get; private set; }

        public File File { get; set; }

        public Acquirer()
        {

        }
        public Acquirer(string tipo, string estabelecimento, string dataproc, string periodoini, string periodofi, string sequencial, string adq)
        {
            if (adq.Equals("FagammonCard"))
            {
                TipoRegistro = tipo;
                DataProcessamento = dataproc;
                Estabelecimento = estabelecimento;
                Adquirente = adq;
                Sequencial = sequencial;
            }
            else
            {
                TipoRegistro = tipo;
                Estabelecimento = estabelecimento;
                DataProcessamento = dataproc;
                PeriodoInicial = periodoini;
                PeriodoFinal = periodofi;
                Sequencial = sequencial;
                Adquirente = adq;
            }
        }
    }
}
