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
    public class PedidosController : ControllerBase
    {
        private readonly TodoContext _context;

        public PedidosController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Pedido>>> GetTodoPedido()
        //{
        //    var pedidos = await _context.TodoPedido.Include(pedidos => pedidos.produtos).Include(pedidos => pedidos.usuario).ToListAsync();   
        //    return pedidos; 
        //}

        //// GET: api/Pedidos/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Pedido>> GetPedido(long id)
        //{
        //    var pedido = await _context.TodoPedido.FindAsync(id);

        //    if (pedido == null)
        //    {
        //        return NotFound();
        //    }

        //    return pedido;
        //}

        //// PUT: api/Pedidos/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPedido(long id, Pedido pedido)
        //{
        //    if (id != pedido.idPedido)
        //    {
        //        return BadRequest();
        //    }
        //    //_context.Attach(pedido); 
        //    //_context.Entry(pedido).State = EntityState.Modified;            

        //    try
        //    {
        //        await DeletePedido(id);
        //        _context.TodoPedido.Add(pedido);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PedidoExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Ok(pedido);
        //}

        //// POST: api/Pedidos
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Pedido>> PostPedido(List<ProdutoCesta> produtos)
        //{
        //    Pedido pedido = new LojaBusiness().CriaPedido(produtos);

        //    _context.TodoPedido.Add(pedido);
        //    await _context.SaveChangesAsync();

        //    return Ok(pedido);
        //    //return CreatedAtAction("GetProduto", new { id = produtos.id }, produtos);
        //}

        //// DELETE: api/Pedidos/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Pedido>> DeletePedido(long id)
        //{
        //    var pedido = _context.TodoPedido.Include(pedidos => pedidos.produtos).Include(pedidos => pedidos.usuario).Where(x => x.idPedido == id).FirstOrDefault();
        //    if (pedido == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoPedido.Remove(pedido);
        //    await _context.SaveChangesAsync();

        //    return pedido;
        //}

        //private bool PedidoExists(long id)
        //{
        //    return _context.TodoPedido.Any(e => e.idPedido == id);
        //}
    }
}
