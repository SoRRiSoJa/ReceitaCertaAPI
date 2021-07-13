using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceitaCertaAPI.Domain.Models
{
    /// <summary>
    /// Unidade de Medida genérica para o sistema
    /// </summary>
    public class UnidadeMedida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnidadeMedidaId { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }
        /// <summary>
        /// CommonCode
        /// </summary>
        [MaxLength(3)]
        public string CCD { get; set; }
        /// <summary>
        /// Sigla para apresentação
        /// </summary>
        [MaxLength(10)]
        public string Sigla { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
