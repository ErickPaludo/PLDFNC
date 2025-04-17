using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.ModelObjects
{
    public class Geral
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Decricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Dthr { get; set; }
        public string Parcela { get; set; }
        public string Categoria { get; set; }
        public string Status { get; set; }
    }
}
