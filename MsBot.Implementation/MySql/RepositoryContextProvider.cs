using Microsoft.Extensions.Configuration;
using MsBot.Domain;

namespace MsBot.Implementation.MySql;

public class RepositoryContextProvider : IRepositoryContextProvider
{
    private readonly IConfiguration _configuration;

    public RepositoryContextProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IRepositoryContext GetRepositoryContext(string key)
    {
        var connStr= _configuration.GetConnectionString(key);
        if (string.IsNullOrEmpty(connStr))
            throw new Exception($"未找到连接配置{key}，请检查");

        return new RepositoryContext(connStr);
    }
}