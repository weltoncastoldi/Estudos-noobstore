using System.Threading.Tasks;
using NoobStore.Core.Messages;

namespace NoobStore.Core.Bus
{
    public interface IMediatrHandler
    {
        /// <summary>
        /// Fazer a publicacao de evento se a classe for do tipo evento
        /// </summary>
        /// <param name="evento"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task PublicarEvento<T>(T evento) where T : Evento;
    }
}