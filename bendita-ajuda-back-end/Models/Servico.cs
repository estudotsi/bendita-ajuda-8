using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bendita_ajuda_back_end.Models
{
	[Table("Servicos")]
	public class Servico
	{
		[Key]
        public int ServicoId { get; set; }
		[Required]
		[StringLength(80)]
		public string? Nome { get; set; }
		[Required]
		[StringLength(300)]
		public string? ImagemUrl { get; set; }
		public int CategoriaId {  get; set; }
		public Categoria? Categoria { get; set; }
	}
}
