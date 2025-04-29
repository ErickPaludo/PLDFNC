namespace WebApiFinanc.Models.DTOs
{
    public class Geral
    {
        public int Id { get; set; }                  
        public string  GpId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Dthr { get; set; }
        public string Parcela { get; set; }
        public string Categoria {  get; set; }
        public string Status {  get; set; } 
    }
}
