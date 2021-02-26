using System.Threading.Tasks;
using MediatR;
using NoobStore.Core.Messages;

namespace NoobStore.Core.Bus
{
   
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Evento
        {
            await _mediator.Publish(evento);
        }
    }
}