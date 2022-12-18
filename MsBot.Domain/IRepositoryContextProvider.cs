namespace MsBot.Domain;

public interface IRepositoryContextProvider
{
    IRepositoryContext GetRepositoryContext(string key);
}