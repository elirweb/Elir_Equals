using System.Collections.Generic;

namespace Equals_DomainService.Entites
{
    public class File
    {
        public Acquirer Acquirer { get; set; }
        public int IdAcquirer { get; private set; }
        public string StatusFile { get;  set; }
        public List<Acquirer> ListAcquirer { get; set; } = new List<Acquirer>();
        public File()
        {

        }

        public File(int acquirer, string status)
        {
            IdAcquirer = acquirer;
            StatusFile = status;
        }
    }
}

