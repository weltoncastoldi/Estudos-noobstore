using System;
using NoobStore.Catalogo.Domain.Entidades;
using NoobStore.Catalogo.Domain.ObjetosValor;
using NoobStore.Core.DomainObjects;
using NUnit.Framework;

namespace NoobStore.Catalogo.Domain.Tests
{
    public class ProdutoTest
    {
        [Test]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Descricao", false, 100, "Imagem", Guid.NewGuid(), DateTime.Now,
                    new Dimensoes(2, 2, 2)));
            Assert.AreEqual("O campo nome do produto nao pode estar vazio", ex.Message);


            var ex = Assert.Throws<DomainException>(() =>
                new Produto("Nome", string.Empty, false, 100, "Imagem", Guid.NewGuid(), DateTime.Now,
                    new Dimensoes(2, 2, 2)));
            Assert.AreEqual("O campo nome do produto nao pode estar vazio", ex.Message);

        }
    }
}