using System.Threading.Tasks;
using NoobStore.Core.Messages;

namespace NoobStore.Core.Bus
{
    public interface IMediatorHandler
    {
        /// <summary>
        /// Fazer a publicacao de evento se a classe for do tipo evento
        /// </summary>
        /// <param name="evento"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task PublicarEvento<T>(T evento) where T : Evento;

        /// <summary>
        /// Fazer a publicacao do comando se a classe for do tipo commmad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="comando"></param>
        /// <returns></returns>
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}