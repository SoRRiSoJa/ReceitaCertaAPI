using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceitaCertaAPI.Domain.Models
{
    /// <summary>
    /// Marca do Produto
    /// </summary>
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarcaId { get; set; }
        [Required]
        [MaxLength(120)]
        public int Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
