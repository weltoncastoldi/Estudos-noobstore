using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NoobStore.Catalogo.Domain.Event;
using NoobStore.Catalogo.Domain.Interfaces;
using NoobStore.Core.Bus;

namespace NoobStore.Catalogo.Domain.Service
{
    //Serviço de dominio representa ações conhecidas da liguagem ubiqua do négocio
    public class EstoqueService : IEstoqueService, IDisposable
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;
        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;
            
            produto.DebitarEstoque(quantidade);

            //Cria um evento para informar que o produto está com estoque baixo.
            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }
            
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);
            
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}