namespace WebApiFinanc.Models.DTOs.Debito
{
    public class DebitoEditDTO
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DthrReg { get; set; }
        public string Status { get; set; }
        
    }
}
