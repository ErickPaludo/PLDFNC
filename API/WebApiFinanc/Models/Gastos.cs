﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [Range(minimum: 0.01, maximum: 99999999999999, ErrorMessage = "Valor mínimo de 0,01 e máximo de 99999999999999")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DthrReg { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        
        public int Parcela { get; set; }

      
        public bool Pago { get; set; }

      
        public char Status { get; set; }

        [Required]
        public char Categoria { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public Usuarios? Usuarios { get; set; }
    }
}
