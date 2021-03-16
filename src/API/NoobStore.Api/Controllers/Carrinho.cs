using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoobStore.Catalogo.Application.Services;

namespace NoobStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Carrinho : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public Carrinho(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);

            if (produto == null) return BadRequest();


        }
    }
}
