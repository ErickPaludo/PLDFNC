using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiFinanc.Models
{
    [Table("DebitoFixo")]
    public class DebitoFixo : Debito
    {
        [Required]
        public DateTime Vencimento { get; set; }

    }
}
