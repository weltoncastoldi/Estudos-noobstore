using AutoMapper;
using NoobStore.Catalogo.Application.ViewModels;
using NoobStore.Catalogo.Domain.Entidades;

namespace NoobStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(p => p.Largura, vm => vm.MapFrom(d => d.Dimensoes.Largura))
                .ForMember(p => p.Altura, vm => vm.MapFrom(d => d.Dimensoes.Altura))
                .ForMember(p => p.Profundidade, vm => vm.MapFrom(d => d.Dimensoes.Profundidade));
        }
    }
}