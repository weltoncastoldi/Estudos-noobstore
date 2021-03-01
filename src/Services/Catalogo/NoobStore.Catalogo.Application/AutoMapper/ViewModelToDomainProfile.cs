using AutoMapper;
using NoobStore.Catalogo.Application.ViewModels;
using NoobStore.Catalogo.Domain.Entidades;
using NoobStore.Catalogo.Domain.ObjetosValor;

namespace NoobStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainProfile: Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));

            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => 
                    new Produto(p.Nome, p.Descricao, p.Ativo, p.Valor, p.Imagem, p.CategoriaId, p.DataCadastro, 
                        new Dimensoes(p.Altura, p.Largura, p.Profundidade)));
        }
    }
}