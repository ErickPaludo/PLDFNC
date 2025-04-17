using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoFNCForms
{
    public class Credito : Gastos
    {
        public double ValorIntegral { get; set; }
        public DateTime DataVencimento { get; set; }
        public int TotalParcelas { get; set; }
    }
}
