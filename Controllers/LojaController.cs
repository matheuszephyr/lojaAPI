using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using LojaAPI.Business;
using LojaAPI.Contexto;
using LojaAPI.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[DisableCors]
    public class LojaController : ControllerBase
    {

        //Por ser um aplicativo com métodos simples não foi criada uma classe contexto.

        private readonly ProdutoContexto _context;        

        public LojaController(ProdutoContexto context)
        {
            _context = context;
        }

        #region GET

        //retorna todos os produtos
        [HttpGet]
        [Route("produto")]
        public ActionResult<List<Produto>> GetTodoProduto()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().OrderBy(x => x.Nome).ToList();
                return produtos;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }        

        //retorna produto pelo ID        
        public Produto GetProdutoPorId(int id)
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().Where(x => x.IdProduto == id).FirstOrDefault();
                return produto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //retorna todos os pedidos
        [HttpGet]
        [Route("pedido")]
        public ActionResult<IEnumerable<Pedido>> GetTodoPedido()
        {
            try
            {
                var pedidos = _context.Pedidos.AsNoTracking().OrderBy(x => x.IdPedido).ToList();
                return pedidos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //retorna pedido por IDPEDIDO
        [HttpGet]
        [Route("pedido/{id}")]
        public ActionResult<List<Pedido>> GetPedidoPorId(long id)
        {
            try
            {
                var pedidos = _context.Pedidos.AsNoTracking().Where(x => x.IdPedido == id).OrderBy(x => x.IdTblPedido).ToList();
                return pedidos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //recebe IDPEDIDO e retorna um objeto PEDIDOCOMPLETO
        [HttpGet]
        [Route("pedidoCompleto/{id}")]
        public ActionResult<PedidoCompleto> GetPedidoCompleto(int id)
        {
            try
            {
                var pedidos = _context.Pedidos.AsNoTracking().Where(x => x.IdPedido == id).OrderBy(x => x.IdTblPedido).ToList();

                if(pedidos.Count() < 1)
                {
                    return NotFound();
                }

                PedidoCompleto pedidoCompleto = new PedidoCompleto();
                pedidoCompleto.Produtos = new List<ProdutoCesta>();
                List<ProdutoCesta> produtos = new List<ProdutoCesta>();

                pedidoCompleto.IdPedido = id;
                pedidoCompleto.IdUsuario = 0;

                foreach(Pedido pedido in pedidos){

                    Produto prod = GetProdutoPorId(pedido.IdProduto);

                    ProdutoCesta prodCesta = new ProdutoCesta(){
                        IdProduto = prod.IdProduto,
                        Imagem = prod.Imagem,
                        Nome = prod.Nome,
                        Quantidade = pedido.Quantidade,
                        Valor = prod.Valor,
                        Total = pedido.Quantidade * prod.Valor
                    };

                    produtos.Add(prodCesta);
                }

                pedidoCompleto.Produtos = produtos;

                return pedidoCompleto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //retorna todos os usuarios
        [HttpGet]
        [Route("usuario")]
        public ActionResult<IEnumerable<Usuario>> GetTodoUsuario()
        {
            try
            {
                var usuarios = _context.Usuarios.AsNoTracking().ToList();
                return usuarios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //retorna usuario por id
        [HttpGet]
        [Route("usuario/{id}")]
        public ActionResult<Usuario> GetUsuarioPorId(long id)
        {
            try
            {
                var usuarios = _context.Usuarios.AsNoTracking().Where(x => x.IdUsuario == id).FirstOrDefault();
                return usuarios;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion GET

        #region POST

        //insere novo produto
        [HttpPost]
        [Route("produto")]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            try
            {

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return (produto);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //insere novo usuario
        [HttpPost]
        [Route("usuario")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //recebe uma lista de produtos e cria um novo pedido retornando o numero do pedido gerado
        [HttpPost]
        [Route("pedido")]
        public async Task<ActionResult<int>> PostPedido(List<Produto> produtos)
        {
            try
            {
                var seq = _context.Pedidos.AsNoTracking().ToList().OrderBy(x => x.IdTblPedido).LastOrDefault().IdTblPedido;
                var seqPedido = seq + 1;

                foreach(Produto prod in produtos){
                    Pedido pedido = new Pedido();

                    pedido.IdTblPedido = seq + 1;
                    pedido.IdPedido = seqPedido;
                    pedido.IdProduto = prod.IdProduto;
                    pedido.Valor = prod.Valor;
                    pedido.Quantidade = 1;
                    pedido.Total = prod.Valor;

                    _context.Pedidos.Add(pedido);
                    await _context.SaveChangesAsync();
                    seq = seq + 1;

                }
                
                //await _context.SaveChangesAsync();

                return Ok(seqPedido);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion POST

        #region PUT

        //recebe IDPEDIDO + obj pedido atualizado e atualiza o pedido no banco
        [HttpPut("pedido/{id}")]
        public async Task<IActionResult> PutPedido(long id, Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return BadRequest();
            }

            try
            {
                _context.Attach(pedido); 
                _context.Entry(pedido).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var pd = _context.Pedidos.Where(x => x.IdPedido == id).ToList();

                if (pd.Count() > 0)
                {
                    return BadRequest();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(pedido);
        }

        //recebe um PEDIDOCOMPLETO e atualiza o pedido no banco, Retorna o ID para ser atribuido no novo usuario
        [HttpPut("pedido")] 
        public async Task<ActionResult<int>> AtualizaPedido(PedidoCompleto pedidoCompleto)
        {
            if (pedidoCompleto == null)
            {
                return BadRequest();
            }

            int idUsu = _context.Usuarios.AsNoTracking().ToList().OrderBy(x => x.IdUsuario).LastOrDefault().IdUsuario + 1;

            try
            {
                foreach(ProdutoCesta produtoCesta in pedidoCompleto.Produtos)
                {
                    int idTbl = _context.Pedidos.AsNoTracking().Where(x => x.IdPedido == pedidoCompleto.IdPedido && x.IdProduto == produtoCesta.IdProduto).FirstOrDefault().IdTblPedido;                    

                    Pedido pedidoAtt = new Pedido()
                    {

                        IdTblPedido = idTbl,
                        IdPedido = pedidoCompleto.IdPedido,
                        IdProduto = produtoCesta.IdProduto,
                        Quantidade = produtoCesta.Quantidade,
                        Valor = produtoCesta.Valor,
                        Total = produtoCesta.Quantidade * produtoCesta.Valor,
                        IdUsuario = idUsu                        
                    };


                    var a = await PutPedido(pedidoAtt.IdPedido , pedidoAtt);

                    //_context.Entry(pedidoAtt).State = EntityState.Modified;
                    //await _context.SaveChangesAsync();
                }                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(idUsu);
        }

        #endregion PUT

        #region DELETE

        //recebe IDPEDIDO e lista de IDPRODUTO e remove produtos do pedido, retorna o pedido excluido
        [HttpPost]
        [Route("pedidodelete/{id}")]
        public async Task<ActionResult> DeleteProdutosPedido(long id, ProdsExcluidos excluidos)
        {
            try
            {
                if (id < 1 || excluidos.listaIds.Count() < 1)
                {
                    return BadRequest();
                }

                foreach (int idprod in excluidos.listaIds)
                {
                    var pedido = _context.Pedidos.Where(x => x.IdPedido == id && x.IdProduto == idprod).AsNoTracking().FirstOrDefault();

                    if (pedido != null)
                    {
                        _context.Pedidos.Remove(pedido);
                        await _context.SaveChangesAsync();
                    }
                }

                return Ok(excluidos);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion DELETE

        //[HttpGet]             
        //public IEnumerable<Produto> GetAll()
        //{
        //    try
        //    {
        //        var resp = new LojaBusiness().ListaProdutos();
        //        return resp;
        //    }
        //    catch(Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}


        //[HttpPost]
        //public bool AdicionaPedido(List<Produto> produtos)
        //{
        //    try
        //    {
        //        if(produtos.Count() <= 0 || produtos == null)
        //        {
        //            return false;
        //        }

        //        new LojaBusiness().CriaPedido(produtos);

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}      



    }
}
