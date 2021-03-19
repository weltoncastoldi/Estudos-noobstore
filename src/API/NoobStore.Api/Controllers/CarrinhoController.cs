using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoobStore.Catalogo.Application.Services;
using NoobStore.Vendas.Application.Commands;

namespace NoobStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public CarrinhoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {

            }
            
            var comando = new AdicionarItemPedidoCommand(clienteId, produto.Id, produto.Nome,quantidade,produto.Valor);

        }
    }
}
