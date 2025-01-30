using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WebApiFinanc.Models
{
    [Table("Debito")]
    public class Debito
    {
        [Key]
        public string DebitoId { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(minimum: 0.01, maximum: 99999999999999, ErrorMessage = "Valor mínimo de 0,01 e máximo de 99999999999999")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; }

        // Chave estrangeira para a tabela Usuarios
        [Required]
        public int UserId { get; set; }

        public Usuarios? Usuarios { get; set; }
    }

}
