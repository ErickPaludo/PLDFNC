using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiFinanc.Models
{
    [Table("tb_gastos_status")]

    public class GastosStatus
    {
        public int Id { get; set; }

        [Required]
        public int GPaiId { get; set; }

        [ForeignKey("GPaiId")]
        [JsonIgnore]
        public Gastos? FkGasto { get; set; }

        [Range(1, 99999)]
        public int Parcela { get; set; }

        [DefaultValue("N")]
        [StringLength(1)]
        public string Status { get; set; }


    }
}
