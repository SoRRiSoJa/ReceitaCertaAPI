using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceitaCertaAPI.Domain.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nome { get; set; }
        [MaxLength(60)]
        public string CEST { get; set; }
        [MaxLength(60)]
        public string NCM { get; set; }
        public decimal PesoBruto { get; set; }
        public int QtdItensContidos { get; set; }
        [MaxLength(120)]
        public string CodigoBarras { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        
    }
}
