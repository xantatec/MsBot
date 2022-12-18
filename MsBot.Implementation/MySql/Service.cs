using MsBot.Domain;

namespace MsBot.Implementation.MySql;

public abstract class Service : IService
{
    private RepositoryContext _msBotContext;

    /// <summary>
    /// MsBot
    /// </summary>
    protected RepositoryContext MsBotContext
    {
        get
        {
            return _msBotContext ??= (RepositoryContext)ContextProvider.GetRepositoryContext("MsBot");
        }
    }


    public IRepositoryContextProvider ContextProvider { get; }

    protected Service(IRepositoryContextProvider contextProvider)
    {
        ContextProvider = contextProvider;
    }
}