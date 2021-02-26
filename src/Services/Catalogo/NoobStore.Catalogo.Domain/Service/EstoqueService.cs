using System;
using System.Threading.Tasks;
using NoobStore.Catalogo.Domain.Interfaces;

namespace NoobStore.Catalogo.Domain.Service
{
    //Serviço de dominio representa ações conhecidas da liguagem ubiqua do négocio
    public class EstoqueService : IEstoqueService, IDisposable
    {
        private readonly IProdutoRepository _produtoRepository;
        public EstoqueService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;
            
            produto.DebitarEstoque(quantidade);
            
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