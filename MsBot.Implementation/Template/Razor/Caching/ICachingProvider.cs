using Microsoft.Extensions.Primitives;

namespace MsBot.Implementation.Template.Razor.Caching;

public interface ICachingProvider
{
    TemplateCacheLookupResult RetrieveTemplate(string key);

    void CacheTemplate(string key, Func<ITemplatePage> pageFactory, IChangeToken expirationToken);

    bool Contains(string key);

    void Remove(string key);
}
