
using System;
using System.Collections.Generic;
using System.IO;

namespace Equals_Application.App
{
    public class AppAcquirer : Service.ServiceAcquirer, Interfaces.IAcquirer
    {
        private Equals_DomainService.Entites.Acquirer _acquirer = new Equals_DomainService.Entites.Acquirer();
        public AppAcquirer(Equals_Infra.Uow.IUoW ou): base(ou)
        {

        }
        public Equals_DomainService.Entites.Acquirer Add(Input.Acquirer model)
        {
            var naoprocessados = $@"C:\naoprocessados\{model.Name}.txt";
            var processados = $@"C:\processados\{model.Name}.txt";

            var _sequencial = string.Empty;
            DateTime data = DateTime.Today;
            DateTime _lastDay = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            DateTime _firtDay = new DateTime(data.Year, data.Month, 1);
            int day = 0;
            StreamWriter writer;
            List<Equals_DomainService.Entites.Acquirer> ListAcquirer = new List<Equals_DomainService.Entites.Acquirer>();
            if (File.Exists(naoprocessados))
            {
                using (StreamReader ReadAcquirer = new StreamReader(naoprocessados))
                {
                    string text = ReadAcquirer.ReadLine();
                    if (text is null)
                    {
                        _acquirer.Status = Equals_Util.Enums.Status.NaoProcessado;
                        ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer("",
                                   "", "", "", "","",
                                   ""));
                        
                    }
                    else
                    {
                        if (model.Periodicidade.Equals(Equals_Util.Enums.Periodicidade.Diario.ToString()))
                        {
                            for (int i = Convert.ToInt32(_firtDay); i < Convert.ToInt32(_lastDay); i++)
                            {
                                ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                    text.Substring(1, 10), data.ToString().Replace("/", ""), data.AddDays(day).ToString().Replace("/", ""), data.AddDays(day).ToString().Replace("/", ""), _sequencial.PadLeft(7, '0'),
                                    text.Substring(42, 8)));
                                day = 1;
                            }
                        }
                        else
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                    text.Substring(1, 10), data.ToString().Replace("/", ""), data.AddDays(day).ToString().Replace("/", ""), data.AddDays(day).ToString().Replace("/", ""), _sequencial.PadLeft(7, '0'),
                                    text.Substring(42, 8)));
                                day = 7;
                            }

                        }

                        if (ListAcquirer.Count > 0)
                        {

                            _context.Acquirer.Add(Equals_Application.Mapper.Acquirer.Acquirers(ListAcquirer));
                            _context.Commit();

                        }

                        writer = File.CreateText(processados);
                        ListAcquirer.ForEach(item => writer.WriteLine(string.Concat(item.TipoRegistro, item.Estabelecimento, item.DataProcessamento,
                            item.PeriodoInicial, item.PeriodoFinal, item.Sequencial, item.Adquirente)));
                        writer.Close();

                        _acquirer.Status = Equals_Util.Enums.Status.Processado;
                    }

                }

            }
            else
                _acquirer.Status = Equals_Util.Enums.Status.ArquivoNaoExiste;

            return _acquirer;
        }
    }
}
