using MsBot.Domain;

namespace MsBot.Implementation.MySql
{
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private RepositoryContext _msBotContext;

        protected Repository(IRepositoryContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

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

        public TAggregateRoot Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}