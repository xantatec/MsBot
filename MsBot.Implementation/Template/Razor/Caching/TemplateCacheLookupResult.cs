namespace MsBot.Implementation.Template.Razor.Caching;

public class TemplateCacheLookupResult
{
    public TemplateCacheLookupResult()
    {
    }

    public TemplateCacheLookupResult(TemplateCacheItem cacheItem)
    {
        Template = cacheItem;
        Success = true;
    }

    public TemplateCacheItem Template { get; set; }

    public bool Success { get; }
}
