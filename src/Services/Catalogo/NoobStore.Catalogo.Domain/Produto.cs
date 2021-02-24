using System;
using NoobStore.Catalogo.Domain.DomainObjects;

namespace NoobStore.Catalogo.Domain
{
    public class Produto : Entidade, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, string imagem, Guid categoriaId, DateTime dataCadastro)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
        }

        public void Ativar() => Ativo = true;
        
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria )
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
    }

    public class Categoria : Entidade
    {
        
    }
}