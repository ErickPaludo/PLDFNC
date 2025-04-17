using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoFNCForms
{
    public abstract class Gastos
    {
        public int id { get; set; }
        public string? titulo { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public DateTime dthrReg { get; set; }
        public string? status { get; set; }
        public int userId { get; set; }
    }
}
