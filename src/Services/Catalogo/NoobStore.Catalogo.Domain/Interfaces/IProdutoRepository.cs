using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoobStore.Catalogo.Domain.Entidades;
using NoobStore.Core.Data;

namespace NoobStore.Catalogo.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodo();
        Task<Produto> ObterPorId(Guid id);
        
        Task<IEnumerable<Produto>> ObterPorCategoria();
        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);

        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}