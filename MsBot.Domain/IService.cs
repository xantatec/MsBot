namespace MsBot.Domain;

public interface IService
{
    IRepositoryContextProvider ContextProvider { get; }
}