namespace MsBot.Domain
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        IRepositoryContextProvider ContextProvider { get; }
    }
}