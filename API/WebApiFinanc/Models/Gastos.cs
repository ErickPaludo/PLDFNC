using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace WebApiFinanc.Models
{
    [Table("tb_financ")]
    public class Gastos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(minimum: 0.01, maximum: 9999999999999, ErrorMessage = "Valor mínimo de 0,01 e máximo de 9999999999999")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DthrReg { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Range(1, 99999)]
        public int Parcela { get; set; }

        [DefaultValue(false)]
        public bool Pago { get; set; }
      
        [Required]
        public char Categoria { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }
    }
}
