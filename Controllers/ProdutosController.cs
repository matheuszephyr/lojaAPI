using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Contexto;
using LojaAPI.Entidades;
using LojaAPI.Business;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly TodoContext _context;

        LojaBusiness business = new LojaBusiness();

        public ProdutosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ProdutoCesta>>> GetTodoItems()
        //{
        //    var produtos = business.ListaProdutos();

        //    foreach (ProdutoCesta prod in produtos)
        //    {
        //        await PostProduto(prod);
        //    }

        //    return produtos;   //await _context.TodosProdutos.ToListAsync();
        //}

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoCesta>> GetProduto(long id)
        {
            var produto = await _context.TodosProdutos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(long id, ProdutoCesta produto)
        {
            //if (id != produto.id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ProdutoExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/Produtos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<ProdutoCesta>> PostProduto(ProdutoCesta produto)
        //{
        //    _context.TodosProdutos.Add(produto);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduto", new { id = produto.id }, produto);
        //}

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoCesta>> DeleteProduto(long id)
        {
            var produto = await _context.TodosProdutos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.TodosProdutos.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        //private bool ProdutoExists(long id)
        //{
        //    return _context.TodosProdutos.Any(e => e.id == id);
        //}
    }
}
