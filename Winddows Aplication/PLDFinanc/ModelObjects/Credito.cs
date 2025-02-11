using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLDFinanc.ModelObjects
{
    public class Credito
    {
        public int CreditoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }     
        public decimal Valor { get; set; }       
        public DateTime DataCompra { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Parcela { get; set; }      
        public int ParcelaTotal { get; set; }
        public int UserId { get; set; }
    }
}
