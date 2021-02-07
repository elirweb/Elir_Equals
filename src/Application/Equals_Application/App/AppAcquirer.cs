
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Equals_Application.App
{
    public class AppAcquirer : Service.ServiceAcquirer, Interfaces.IAcquirer
    {
        private readonly Equals_DomainService.Entites.Acquirer _acquirer = new Equals_DomainService.Entites.Acquirer();
        public AppAcquirer(Equals_Infra.Uow.IUoW ou): base(ou)
        {

        }
        public Equals_DomainService.Entites.Acquirer Add(Input.Acquirer model)
        {
            var naoprocessados = $@"{Equals_Util.WebConfig.naoprocessados}{model.Name}.txt";
            

            int _sequencial = 0;
            int cont = 0;
            string _diferencial = string.Empty;
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
                            for (int i = Convert.ToInt32(_firtDay.Day); i <=Convert.ToInt32(_lastDay.Day); i++)
                            {
                               
                                switch (model.Name) {
                                    case "FagammonCard":
                                        _sequencial = Convert.ToInt32(text.Substring(29, 7));
                                        ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                     text.Substring(9, 8), data.AddDays(day).ToString("yyyyMMdd").Replace("/", ""), null, null,
                                      string.Concat("000", Convert.ToString(_sequencial + cont)), text.Substring(17, 12)));
                                        break;

                                    case "UflaCard":
                                        _sequencial = Convert.ToInt32(text.Substring(35, 7));
                                        ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                    text.Substring(1, 10), data.AddDays(day).ToString("yyyyMMdd").Replace("/", ""), data.AddDays(day).ToString("yyyyMMdd").Replace("/","").ToString(), data.AddDays(day).ToString("yyyyMMdd").ToString().Replace("/",""),
                                     string.Concat("000000", Convert.ToString(_sequencial + cont)), text.Substring(42, 7)));
                                        break;
                                }
                                
                                day+=1;
                                cont += 1;
                                
                            }
                        }
                        else
                        {
                            for (int i = 1; i <=4; i++)
                            {
                                switch (model.Name)
                                {
                                    case "FagammonCard":
                                        _sequencial = Convert.ToInt32(text.Substring(29, 7));
                                        ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                     text.Substring(9, 8), data.AddDays(day).ToString("yyyyMMdd").Replace("/", ""), null, null,
                                      string.Concat("000", Convert.ToString(_sequencial + cont)), text.Substring(17, 12)));
                                        break;

                                    case "UflaCard":
                                        _sequencial = Convert.ToInt32(text.Substring(35, 7));
                                        ListAcquirer.Add(new Equals_DomainService.Entites.Acquirer(text.Substring(0, 1),
                                    text.Substring(1, 10), data.AddDays(day).ToString("yyyyMMdd").Replace("/", ""), data.AddDays(day).ToString("yyyyMMdd").Replace("/", "").ToString(), data.AddDays(day).ToString("yyyyMMdd").ToString().Replace("/", ""),
                                     string.Concat("000000", Convert.ToString(_sequencial + cont)), text.Substring(42, 7)));
                                        break;
                                }
                                day +=7;
                               cont += 1;
                            }

                        }

                        foreach (var item in ListAcquirer)
                        {

                            _context.Acquirer.Add(Mapper.Acquirer.Acquirers(item));
                            _context.Commit();

                        }
                        foreach (var item in ListAcquirer)
                        {
                      
                            writer = File.CreateText($@"{Equals_Util.WebConfig.processados}{model.Name}{item.DataProcessamento}.txt");
                          
                            
                            writer.WriteLine(string.Concat(item.TipoRegistro, item.Estabelecimento, item.DataProcessamento,
                                item.PeriodoInicial, item.PeriodoFinal, item.Sequencial, item.Adquirente));

                            writer.Close();
                            
                        }
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
