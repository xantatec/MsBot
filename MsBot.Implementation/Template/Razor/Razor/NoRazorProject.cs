namespace MsBot.Implementation.Template.Razor.Razor;

public sealed class NoRazorProject : RazorLightProject
{
    public override Task<RazorLightProjectItem> GetItemAsync(string templateKey)
    {
        return Task.FromResult((RazorLightProjectItem)NoRazorProjectItem.Empty);
    }

    public override Task<IEnumerable<RazorLightProjectItem>> GetImportsAsync(string templateKey)
    {
        return Task.FromResult(Enumerable.Empty<RazorLightProjectItem>());
    }

    public override Task<IEnumerable<string>> GetKnownKeysAsync()
    {
        return Task.FromResult(Enumerable.Empty<string>());
    }
}
