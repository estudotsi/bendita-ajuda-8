using bendita_ajuda_back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace bendita_ajuda_back_end.Data
{
	public class BenditaAjudaDbContext : DbContext
	{
		public BenditaAjudaDbContext(DbContextOptions<BenditaAjudaDbContext> options) : base(options)
		{

		}

		public DbSet<Categoria>? Categorias { get; set; }
		public DbSet<Servico>? Servicos { get; set; }
	}
}
