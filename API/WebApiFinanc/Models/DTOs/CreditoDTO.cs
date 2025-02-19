﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace WebApiFinanc.Models.DTOs
{
    public class CreditoDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titulo { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [Range(minimum: 0.01, maximum: 99999999999999, ErrorMessage = "Valor mínimo de 0,01 e máximo de 99999999999999")]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }

        public bool Pago { get; set; }

        [DefaultValue('C')]
        public char Categoria { get; set; }

        [Required]
        public DateTime DataCompra { get; set; }

        [Range(1, 99999)]
        [Required]
        public int ParcelaTotal { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
