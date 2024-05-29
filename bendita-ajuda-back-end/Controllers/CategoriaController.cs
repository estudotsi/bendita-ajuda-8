using bendita_ajuda_back_end.Data;
using bendita_ajuda_back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bendita_ajuda_back_end.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		private readonly BenditaAjudaDbContext _context;

		public CategoriaController(BenditaAjudaDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Categoria>> GetCategorias()
		{
			var categorias = _context.Categorias.AsNoTracking().ToList();

			if (categorias is null)
			{
				return NotFound("Categorias não encontradas");
			}

			return categorias;
		}

		[HttpGet("produtos")]
		public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
		{
			var categoriasProdutos = _context.Categorias.Include(s => s.Servicos).AsNoTracking().ToList();

			if (categoriasProdutos is null)
			{
				return NotFound("Categorias e produtos não encontrados");
			}

			return categoriasProdutos;
		}


		[HttpGet("{id:int}", Name = "ObterCategoria")]
		public ActionResult<Categoria> GetCategoria(int id)
		{
			throw new Exception("Excessão");

			var categoria = _context.Categorias.FirstOrDefault(s => s.CategoriaId == id);

			if (categoria is null)
			{
				return NotFound("Categoria não encontrado");
			}

			return Ok(categoria);
		}

		[HttpPost]
		public ActionResult Post(Categoria categoria)
		{
			if (categoria is null)
				return BadRequest("Categoria não enviada");

			_context.Categorias.Add(categoria);
			_context.SaveChanges();

			return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
		}

		[HttpPut("{id:int}")]
		public ActionResult Put(Categoria categoria, int id)
		{
			if (id != categoria.CategoriaId)
			{
				return BadRequest();
			}

			_context.Entry(categoria).State = EntityState.Modified;
			_context.SaveChanges();

			return Ok(categoria);
		}

		[HttpDelete("{id:int}")]
		public ActionResult Delete(int id)
		{
			var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

			if (categoria is null)
			{
				return NotFound("Categoria não encontrada");
			}

			_context.Categorias.Remove(categoria);
			_context.SaveChanges();

			return Ok(categoria);
		}
	}
}
