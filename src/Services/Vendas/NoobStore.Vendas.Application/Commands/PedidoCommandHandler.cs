using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NoobStore.Core.Messages;

namespace NoobStore.Vendas.Application.Commands
{
    public class PedidoCommandHandler: IRequestHandler<AdicionarItemPedidoCommand, bool>
    {
        public Task<bool> Handle(AdicionarItemPedidoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValid()) return true;
            
            
        }
    }
}