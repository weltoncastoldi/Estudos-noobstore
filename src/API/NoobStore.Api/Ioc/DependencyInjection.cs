using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NoobStore.Catalogo.Application.Services;
using NoobStore.Catalogo.Data;
using NoobStore.Catalogo.Data.Repository;
using NoobStore.Catalogo.Domain.Event;
using NoobStore.Catalogo.Domain.Interfaces;
using NoobStore.Catalogo.Domain.Service;
using NoobStore.Core.Bus;
using NoobStore.Vendas.Application.Commands;

namespace NoobStore.Api.Ioc
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            //Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

        }
    }
}
