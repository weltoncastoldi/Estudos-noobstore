using System;

namespace NoobStore.Core.Messages
{
    public abstract class Mensagem
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        public Mensagem()
        {
            MessageType = GetType().Name; // Retorna o nome da Classe que está implementando a Mensagem
        }
    }
}