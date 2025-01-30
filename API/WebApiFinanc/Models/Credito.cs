using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiFinanc.Models
{
    [Table("Credito")]
    public class Credito
    {
        [Key]
        public string CreditoId { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(minimum: 0.01, maximum: 99999999999999, ErrorMessage = "Valor mínimo de 0,01 e máximo de 99999999999999")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }
        [Required]
        public int Parcela { get; set; }
        [Required]
        public int ParcelaTotal { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }
    }
}
