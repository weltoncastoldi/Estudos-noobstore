using MediatR;
using NoobStore.Catalogo.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NoobStore.Catalogo.Domain.Event
{
    public class ProdutoEventHandler: INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent notification, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorId(notification.AggregateId);

            // Enviar email para aquisição de mais produtos.
            // Manda sms etc
            // etc etc

        }
    }
}
