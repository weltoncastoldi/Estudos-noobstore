using System;
using FluentValidation.Results;
using MediatR;

namespace NoobStore.Core.Messages
{
    /// <summary>
    /// Comando é classe abstrada e não pode ser instanciada apenas herdada
    /// </summary>
    public abstract class Command : Mensagem, IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
    
        protected Command(){Timestamp = DateTime.Now;}
        
        public virtual bool EhValid()
        {
            throw new NotImplementedException();
        }
    }
}