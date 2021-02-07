using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Equals_Domain.Entites
{
    public class File: Base.Entity
    {
        public Acquirer Acquirer { get;  set; }
        public int IdAcquirer { get; private set; }
        public string StatusFile { get; private set; }
        [NotMapped]
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
