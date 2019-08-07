using System;
using NerdStore.Core.DomainObject;

namespace NerdStore.Core.Data
{
    //Classe genérica
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork unitOfWork { get; }
    }
}