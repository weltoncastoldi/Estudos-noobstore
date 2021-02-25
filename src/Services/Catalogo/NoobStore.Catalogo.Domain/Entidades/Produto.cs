using System;
using NoobStore.Catalogo.Domain.ObjetosValor;
using NoobStore.Core.DomainObjects;

namespace NoobStore.Catalogo.Domain.Entidades
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
        public Dimensoes Dimensoes { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, string imagem, Guid categoriaId, DateTime dataCadastro, Dimensoes dimensoes)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;
            
            Validar();
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

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo nome do produto nao pode estar vazio");
            Validacoes.ValidarSeVazio(Descricao, "o campo descricao nao pode estar vazio");
            Validacoes.ValidarSeDiferente(CategoriaId, Guid.Empty, "O campo categoriaId nao estar vazio");
            Validacoes.ValidarSeMenorIgualMinimo(Valor,0,"O campo valor do produto nao pode ser menor igual a 0");
            Validacoes.ValidarSeVazio(Imagem, "O campo imagem nao pode estar vazio");
        }
        
    }

}