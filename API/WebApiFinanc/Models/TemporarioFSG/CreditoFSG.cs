using WebApiFinanc.Models.DTOs.Credito;

namespace WebApiFinanc.Models.TemporarioFSG
{
    public class CreditoFSG
    {
        public Credito credito { get; set; }
        public List<Parcelas> parcelas { get; set; }
    }
    public class Parcelas
    {
        public int parcela;
        public String status;
    }
}
