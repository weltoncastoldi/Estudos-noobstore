using Microsoft.AspNetCore.Mvc;
using NoobStore.Catalogo.Application.Services;
using NoobStore.Core.Bus;
using NoobStore.Vendas.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NoobStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatorHandler _mediatorHandle;
        public CarrinhoController(IProdutoAppService produtoAppService, IMediatorHandler mediatorHandle)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandle = mediatorHandle;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto == null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                return BadRequest();
            }

            var clienteId = new Guid();
            var command =
                new AdicionarItemPedidoCommand(clienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatorHandle.EnviarComando(command);

            return Ok();
        }
    }
}
