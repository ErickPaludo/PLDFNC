using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.ModelObjects
{
    public class Debito
    {
        public int DebitoId { get; set; }
        public string Descricao { get; set; }    
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int UserId { get; set; }
    }
}
