using System;
using System.ComponentModel.DataAnnotations;

namespace ApiLancamentos.Models
{
    public class Lancamento
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        public double Valor { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao  { get; set; }

        [Required]
        [StringLength(20)]
        public string Conta  { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo  { get; set; }
    }
}