using System;

namespace NoobStore.Core.DomainObjects
{
    /// <summary>
    /// Classe que vai tratar as excecoes de dominio
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innetException) : base(message, innetException)
        {
        }
    }
}