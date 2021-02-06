namespace Equals_Domain.Entites
{
    public class Acquirer : Base.Entity
    {
        private string TipoRegistro { get; set; }
        private string Estabelecimento { get; set; }
        private string DataProcessamento { get; set; }
        private string PeriodoInicial { get; set; }
        private string PeriodoFinal { get; set; }
        private string Sequencial { get; set; }
        private string Adquirente { get; set; }

        public Acquirer(string tipo, string estabelecimento, string dataproc, string periodoini, string periodofi, string sequencial, string adq)
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
