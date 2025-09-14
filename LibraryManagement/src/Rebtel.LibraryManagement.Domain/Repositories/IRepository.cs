using Rebtel.LibraryManagement.Domain.Shared;

namespace Rebtel.LibraryManagement.Domain.Repositories;

public interface IRepository<T> where T : class, IAggregateRoot
{
}
