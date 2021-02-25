using System;
using NoobStore.Core.DomainObjects;

namespace NoobStore.Core.Data
{
    /// <summary>
    /// Obrigatoriamente e necessario passar um Agregado para persistir
    /// O agregado estará marcado com IAggregateRoot
    /// </summary>
    /// <typeparam name="T">Classe</typeparam>
    public interface IRepository <T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}