using MsBot.Implementation.Template.Razor.Caching;
using MsBot.Implementation.Template.Razor.Compilation;
using System.Dynamic;

namespace MsBot.Implementation.Template.Razor;

public interface IEngineHandler
{
    ICachingProvider Cache { get; }
    IRazorTemplateCompiler Compiler { get; }
    ITemplateFactoryProvider FactoryProvider { get; }

    RazorLightOptions Options { get; }
    bool IsCachingEnabled { get; }

    Task<ITemplatePage> CompileTemplateAsync(string key);

    Task<string> CompileRenderAsync<T>(string key, T model, ExpandoObject viewBag = null);
    Task<string> CompileRenderStringAsync<T>(string key, string content, T model, ExpandoObject viewBag = null);

    Task<string> RenderTemplateAsync<T>(ITemplatePage templatePage, T model, ExpandoObject viewBag = null);
    Task RenderTemplateAsync<T>(ITemplatePage templatePage, T model, TextWriter textWriter, ExpandoObject viewBag = null);
    Task RenderIncludedTemplateAsync<T>(ITemplatePage templatePage, T model, TextWriter textWriter, ExpandoObject viewBag, TemplateRenderer templateRenderer);
}