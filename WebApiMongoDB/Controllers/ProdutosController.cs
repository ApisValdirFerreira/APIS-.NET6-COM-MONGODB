using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDB.Models;
using WebApiMongoDB.Services;

namespace WebApiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoServices _produtoServices;

        public ProdutosController(ProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProdutos()
            => await _produtoServices.GetAsync();

        [HttpPost]
        public async Task<Produto> PostProduto(Produto produto)
        {
            await _produtoServices.CreateAsync(produto);

            return produto;
        }

        [HttpGet("{id}")]
        public async Task<Produto> GetById(string id)
        {
            return await _produtoServices.GetAsync(id);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Produto produto)
        {
            try
            {
                await _produtoServices.UpdateAsync(id, produto);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("dados inválidos");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult>  Delete(string id)
        {
            try
            {
                await _produtoServices.RemoveAsync(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("dados inválidos");
            }
          
        }

    }

}
}
